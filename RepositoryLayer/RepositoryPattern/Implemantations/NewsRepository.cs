﻿using DomainLayer.Entity.Postgre;
using DomainLayer.Model;
using DomainLayer.Model.Enums;
using DomainLayer.Model.News;
using DomainLayer.Model.NewsFile;
using DomainLayer.Model.User;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Extensions;
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
        IHttpContextAccessor _httpContextAccessor;
        public long? _userId { get; set; }
        public NewsRepository(PostgreNewsDbContext dbContext, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _userId = httpContextAccessor.HttpContext.GetUserInfoFromContext();

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
                                join categoryAdmin in _dbContext.Set<CategoryAdminEntity>() on new {news.CategoryId,UserId= _userId } equals new { categoryAdmin.CategoryId, UserId= (Nullable<long>)categoryAdmin.UserId } into grp1
                                from  categoryAdmin in grp1.DefaultIfEmpty() 
                                           where news.CategoryId == categoryId || chilcategoryIds.Contains(news.CategoryId)
                                select new NewsListForCategoryModel() { Id = news.Id, Header = news.Header,UploadDate=news.CreationDate,IsDeletable= categoryAdmin == null ? false: true };
            var newsListForCategoryModelList = await newsListQuery.ToArrayAsync();
            return newsListForCategoryModelList;
        }

        public async Task<ResponseModel> DeleteNewsAndFiles(long newsId)
        {
            var responseModel = new ResponseModel() { HasError = false, Message = "News Deleted." };
            var transaction = await _dbContext.Database.BeginTransactionAsync();
     
            try
            {
                var newsListQuery = from news in _dbContext.Set<NewsEntity>()
                                    where news.Id == newsId
                                    select new NewsEntity() { Id=news.Id};
                var newsFileListQuery = from newsFile in _dbContext.Set<NewsFileEntity>()
                                    where newsFile.NewsId == newsId
                                    select new NewsFileEntity() { Id = newsFile.Id };
                var newsListToRemove = await newsListQuery.ToArrayAsync();
                var newsFileListToRemove = await newsFileListQuery.ToArrayAsync();
                _dbContext.RemoveRange(newsListToRemove);
                _dbContext.RemoveRange(newsFileListToRemove);
                await _dbContext.SaveChangesAsync();
               await transaction.CommitAsync();
            }




            finally
            {
                if (transaction == null)
                {
                

                }
              await  transaction.DisposeAsync();


            }
                  return responseModel;

        }
    }
}

