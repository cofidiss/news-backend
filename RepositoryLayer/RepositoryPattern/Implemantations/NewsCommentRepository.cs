using DomainLayer.Entity.Postgre;
using DomainLayer.Model.NewsComment;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.RepositoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepositoryPattern.Implemantations
{
    public class NewsCommentRepository: GenericRepository<NewsCommentEntity>,INewsCommentRepository
    {
        private readonly DbContext _dbContext;
        public NewsCommentRepository(PostgreNewsDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<IEnumerable<NewsCommentModel>> GetCommentsForNews(long newsId)
        {
            var getCommentsForNewsQuery = from newsComment in _dbContext.Set<NewsCommentEntity>()
                                          join user in _dbContext.Set<UserEntity>() on newsComment.CreatedBy equals user.Id into grp1
                                          from user in grp1.DefaultIfEmpty()
                                          where newsComment.NewsId == newsId
                                          select new NewsCommentModel() { Author = user == null ? "Anonymous": user.UserName , Comment = newsComment.Comment, CreationDate=newsComment.CreationDate };



            var newsCommentModelList = await  getCommentsForNewsQuery.ToArrayAsync();
            return newsCommentModelList;




        }
    }
}
