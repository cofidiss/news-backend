using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using ServicesLayer.Services.Implemantations;
using ServicesLayer.Services.Interfaces;
using System.Threading.Tasks;
using System.Web;
namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsFileController:ControllerBase
    {
        public INewsFileService _newsFileService { get; set; }
        public NewsFileController(INewsFileService newsFileService)
        {
            _newsFileService = newsFileService;

        }
        [HttpGet(nameof(Get))]
        public async Task<IActionResult> Get(long id)
        {
       var newsFileDto =     await _newsFileService.Get(id);



            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(newsFileDto.Name, out string contentType))
            {
                contentType = "application/octet-stream"; 
            }

            return File(newsFileDto.ByteArray, contentType, newsFileDto.Name);
        }
     
    }
}
