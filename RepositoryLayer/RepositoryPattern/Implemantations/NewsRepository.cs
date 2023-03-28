using DomainLayer.Entity.Postgre;
using DomainLayer.Model;
using DomainLayer.Model.Enums;
using DomainLayer.Model.News;
using DomainLayer.Model.NewsFile;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.RepositoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepositoryPattern.Implemantations
{
    public class NewsRepository : GenericRepository<NewsEntity>, INewsRepository
    {
        IConfiguration _configuration;
        private readonly DbContext _dbContext;
        public NewsRepository(PostgreNewsDbContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<NewsAndMetaDataModel> GetNewsAndMetaData(long id)
        {

            string getFileUrl = $"{_configuration["appBaseUrl"]}/api/NewsFile/Get?id=";


            var newsAndMetaDataModelQuey = from news in _dbContext.Set<NewsEntity>()
                                           where news.Id == id
                                           select new NewsAndMetaDataModel() { Id = news.Id, Header = news.Header, Text = news.Body };
            var newsAndMetaDataModelList = await newsAndMetaDataModelQuey.ToArrayAsync();

            var newsFileModelQuery = from newsFile in _dbContext.Set<NewsFileEntity>()
                                     where newsFile.NewsId == id
                                     select new NewsFileMetaDataModel()
                                     {
                                         Name = newsFile.Name,
                                         Type = newsFile.Type,
                                         Url = getFileUrl + newsFile.Id
                                     };
            var newsFileModelList = await newsFileModelQuery.ToArrayAsync();
            var newsAndMetaDataModel = newsAndMetaDataModelList.First();

            newsAndMetaDataModel.Attachments = newsFileModelList.Where(x => x.Type == (long)NewsFileTypeEnum.Attachment);
            newsAndMetaDataModel.Images = newsFileModelList.Where(x => x.Type == (long)NewsFileTypeEnum.Image);
            newsAndMetaDataModel.Videos = newsFileModelList.Where(x => x.Type == (long)NewsFileTypeEnum.Video);


            return newsAndMetaDataModel;



        }

        public async Task<ResponseModel> AddNews(AddNewsModel addNewsModel)
        {
            var responseModel = new ResponseModel() {HasError=false,Message="News Added." };
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                var newsEntityToInsert = new NewsEntity()
                {
                    CategoryId = addNewsModel.CategoryId,
                    CreatedBy = -1,
                    CreationDate = DateTime.Now,
                    Header = addNewsModel.Header,
                    Body = addNewsModel.Body,
                    Id = 0,
                    LastUpdateDate = null,
                    LastUpdatedBy = null
                };  //? düzelt
              await _dbContext.AddAsync(newsEntityToInsert);
                await _dbContext.SaveChangesAsync();
                NewsFileEntity newsFileEntityToInsert=null;

                foreach (var newsFile in addNewsModel.Attachments)
                {
                    newsFileEntityToInsert = new NewsFileEntity() { ByteArray = newsFile.ByteArray, CreatedBy = -1, CreationDate = DateTime.Now,Id=0,
                    LastUpdateDate=null,LastUpdatedBy=null,Name=newsFile.Name,NewsId= newsEntityToInsert
                    .Id,Type= (long)NewsFileTypeEnum.Attachment};  //? düzelt
                    await _dbContext.AddAsync(newsFileEntityToInsert);
                }

                foreach (var newsFile in addNewsModel.Images)
                {
                    newsFileEntityToInsert = new NewsFileEntity()
                    {
                        ByteArray = newsFile.ByteArray,
                        CreatedBy = -1,
                        CreationDate = DateTime.Now,
                        Id = 0,
                        LastUpdateDate = null,
                        LastUpdatedBy = null,
                        Name = newsFile.Name,
                        NewsId = newsEntityToInsert
                      .Id,
                        Type = (long)NewsFileTypeEnum.Image
                    };  //? düzelt
                    await _dbContext.AddAsync(newsFileEntityToInsert);
                }
                foreach (var newsFile in addNewsModel.Videos)
                {
                    newsFileEntityToInsert =  new NewsFileEntity()
                    {
                        ByteArray = newsFile.ByteArray,
                        CreatedBy = -1,
                        CreationDate = DateTime.Now,
                        Id = 0,
                        LastUpdateDate = null,
                        LastUpdatedBy = null,
                        Name = newsFile.Name,
                        NewsId = newsEntityToInsert
                      .Id,
                        Type = (long)NewsFileTypeEnum.Video
                    };  //? düzelt
                    await _dbContext.AddAsync(newsFileEntityToInsert);
                }

               await  _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            return responseModel;
        }



        public async Task<IEnumerable<NewsListForCategoryModel>> GetNewsListForCategory(long categoryId)
        {
           var chilcategoryIds =  (from category in _dbContext.Set<CategoryEntity>()
             where category.ParentId == categoryId
             select category.Id).ToArray();
            var newsListQuery = from news in _dbContext.Set<NewsEntity>()
                                           where news.CategoryId == categoryId || chilcategoryIds.Contains(news.CategoryId)
                                select new NewsListForCategoryModel() { Id = news.Id, Header = news.Header,UploadDate=news.CreationDate };
            var newsListForCategoryModelList = await newsListQuery.ToArrayAsync();
            return newsListForCategoryModelList;
        }
    }
}

