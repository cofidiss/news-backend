using DomainLayer.Entity;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.RepositoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepositoryPattern
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class
    {
        #region property  
        private readonly DbContext _dbContext;
        private DbSet<T> entities;
        #endregion

        #region Constructor  
        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            entities = _dbContext.Set<T>();
        }
        #endregion

  
   

        public async Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> filter)
        {

            return await entities.Where(filter).ToArrayAsync();
        }

        public async Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity is null");
            }  
           await entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }



        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity is null");
            }

             entities.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity is null");
            }
            entities.Remove(entity);
          await _dbContext.SaveChangesAsync();
        }
    }
}
