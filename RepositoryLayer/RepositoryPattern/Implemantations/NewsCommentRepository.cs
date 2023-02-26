using DomainLayer.Entity.Postgre;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.RepositoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
