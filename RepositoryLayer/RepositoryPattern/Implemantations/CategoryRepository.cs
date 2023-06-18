using DomainLayer.Entity.Postgre;
using DomainLayer.Model.Category;
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
    public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
    {
        private readonly DbContext _dbContext;
        public CategoryRepository(PostgreNewsDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
         
        }

      async  Task<IEnumerable<CategoryListForCRUDModel>> ICategoryRepository.GetCategoryListForCRUD()
        {
            var categoryListForCRUDQuery = from category1 in _dbContext.Set<CategoryEntity>()
                                join category2 in _dbContext.Set<CategoryEntity>() on category1.ParentId equals category2.Id into group1
                                from category2 in group1.DefaultIfEmpty()                                
                                select new CategoryListForCRUDModel() { Id = category1.Id, Name = category1.Name, ParentName = category2 == null ? null: category2.Name };
        return   await categoryListForCRUDQuery.ToArrayAsync();


        }

    }
}
