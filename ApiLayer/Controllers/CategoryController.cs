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
    }
}
