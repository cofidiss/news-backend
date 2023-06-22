using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services.Interfaces;
using System.Threading.Tasks;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController:ControllerBase
    {

        public ICategoryService _categoryService { get; set; }
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet(nameof(GetCategoriesForNavBar))]
        public async Task<IActionResult> GetCategoriesForNavBar()
        {
            return Ok(await _categoryService.GetCategoriesForNavBar());
        }
        [HttpGet(nameof(GetCategoryLov))]
        public async Task<IActionResult> GetCategoryLov()
        {
            return Ok(await _categoryService.GetCategoryLov());
        }
        [HttpGet(nameof(GetCategoryListForCRUD))]
        public async Task<IActionResult> GetCategoryListForCRUD()
        {
            return Ok(await _categoryService.GetCategoryListForCRUD());
        }
        [HttpPost(nameof(DeleteCategory))]
        public async Task<IActionResult> DeleteCategory(long id)
        {
            return Ok(await _categoryService.DeleteCategory(id));
        }
        

    }
}
