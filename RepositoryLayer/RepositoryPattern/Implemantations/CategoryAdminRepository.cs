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
    public class CategoryAdminRepository: GenericRepository<CategoryAdminEntity>, ICategoryAdminRepository
    {
        private readonly DbContext _dbContext;
        public CategoryAdminRepository(PostgreNewsDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }
    }
}
