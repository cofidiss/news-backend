using DomainLayer.Entity.Postgre;
using DomainLayer.Model.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepositoryPattern.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<CategoryEntity>
    {
        Task<IEnumerable<CategoryListForCRUDModel>> GetCategoryListForCRUD();
    }
}
