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

        public Task<IEnumerable<NewsCommentModel>> GetCommentsForNews(long newsId)
        {
            var getCommentsForNewsQuery = from newsComment in _dbContext.Set<NewsCommentEntity>()
                                          join user in _dbContext.Set<UserEntity>() into grp1
                                           from user in grp1.DefaultIfEmpty()
                                          select 

        }
    }
}
