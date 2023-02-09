using Microsoft.AspNetCore.Mvc;
using ServicesLayer.DTO.Users;
using ServicesLayer.Services.Interfaces;

namespace ApiLayer.Controllers
{
    public class UsersController : Controller
    {
        public IUsers _usersService { get; set; }
        public UsersController(IUsers usersService)
        {
            _usersService = usersService;
        }
        [HttpPost(nameof(SignUp))]
        public IActionResult SignUp(SignUpDto signUpDto)
        {
            return Ok(_usersService.SignUp(signUpDto));
        }
    }
}
