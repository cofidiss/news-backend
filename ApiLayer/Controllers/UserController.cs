
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.DTO.User;
using ServicesLayer.Services.Interfaces;
using System.Threading.Tasks;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public IUserService _userService { get; set; }
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost(nameof(SignUp))]
        public IActionResult SignUp(SignUpDto signUpDto)
        {
            return Ok(_userService.SignUp(signUpDto));
        }
        [HttpPost(nameof(Login))]
        public IActionResult Login(LoginDto loginDto)
        {
            return Ok(_userService.Login(loginDto));
        }
        [HttpPost(nameof(IsCategoryAdmin))]
        public async Task<IActionResult> IsCategoryAdmin(long categoryId)
        {
            return Ok(await _userService.IsCategoryAdmin(categoryId));
        }
    }
}
