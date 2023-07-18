using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services.Interfaces;
using System.Threading.Tasks;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryAdminController: ControllerBase
    {
        public ICategoryAdminService _categoryAdminService { get; set; }
        public CategoryAdminController(ICategoryAdminService categoryAdminService)
        {
            _categoryAdminService = categoryAdminService;
        }

        [HttpPost(nameof(IsCategoryAdmin))]
        public async Task<IActionResult> IsCategoryAdmin(long categoryId)
        {

            return Ok(await _categoryAdminService.IsCategoryAdmin(categoryId));
        }
    }
}
