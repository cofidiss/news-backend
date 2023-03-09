﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ServicesLayer.Services.Interfaces;
using System.Threading.Tasks;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {
        public INewsService _newsService { get; set; }
        public NewsController(INewsService newsService,IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _newsService = newsService;
         
        }
        [HttpGet(nameof(GetImage))]
        public async Task<IActionResult> GetImage( long id )
        {
          var bytes =  System.IO.File.ReadAllBytes("./Capture.PNG");

            return File(bytes,"image/png");
        }
        [HttpGet(nameof(GetNewsAndMetaData))]
        public async Task<IActionResult> GetNewsAndMetaData(long id)
        {

    

            return Ok( await  _newsService.GetNewsAndMetaData(id));
        }
    }
}
