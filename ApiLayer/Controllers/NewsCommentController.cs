
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.DTO.NewsComment;
using ServicesLayer.DTO.User;
using ServicesLayer.Services.Interfaces;
using System.Threading.Tasks;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsCommentController : Controller
    {
        public INewsCommentService _newsCommentService { get; set; }
        public NewsCommentController(INewsCommentService newsCommentService)
        {
            _newsCommentService = newsCommentService;
        }
        [HttpPost(nameof(Add))]
        public async Task< IActionResult> Add(AddNewsCommentDto addCommentDto)
        {
            return Ok(await _newsCommentService.Add(addCommentDto));
        }
        [HttpPost(nameof(GetCommentsForNews))]
        public async Task<IActionResult> GetCommentsForNews([FromBody] long newsId)
        {
            return Ok(await _newsCommentService.GetCommentsForNews(newsId));
        }

    }
}
