using DomainLayer.Entity.Postgre;
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
                                           select new NewsAndMetaDataModel() { Id = news.Id, Header = news.Header, Text = news.Text };
            var newsAndMetaDataModelList = await newsAndMetaDataModelQuey.ToArrayAsync();

            var newsFileModelQuery = from newsFile in _dbContext.Set<NewsFileEntity>()
                                     where newsFile.NewsId == id
                                     select new NewsFileMetaDataModel()
                                     {
                                         Name = newsFile.Name,
                                         Type = newsFile.Type,
                                         Url = getFileUrl + newsFile.Id
                                     };
            var newsFileModelList =await newsFileModelQuery.ToArrayAsync();
            var newsAndMetaDataModel = newsAndMetaDataModelList.First();

            newsAndMetaDataModel.Attachments = newsFileModelList.Where(x =>x.Type ==(long) NewsFileTypeEnum.Attachment);
            newsAndMetaDataModel.Images = newsFileModelList.Where(x => x.Type == (long)NewsFileTypeEnum.Image);
            newsAndMetaDataModel.Videos = newsFileModelList.Where(x => x.Type == (long)NewsFileTypeEnum.Video);

            return newsAndMetaDataModel;



    }
    }
}

