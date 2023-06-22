using ServicesLayer.DTO;
using ServicesLayer.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoriesForNavBarDto>> GetCategoriesForNavBar();
        Task<IEnumerable<CategoryLovDto>> GetCategoryLov();
        Task<IEnumerable<CategoryListForCRUDDto>> GetCategoryListForCRUD();
        Task<ResponseDto> DeleteCategory(long id);
    }
}
