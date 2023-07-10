
using AutoMapper;
using DomainLayer.Model.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.DTO.User;
using ServicesLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public IUserService _userService { get; set; }
        IMapper _mapper { get; set; }
    public UserController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpPost(nameof(SignUp))]
        public IActionResult SignUp(SignUpDto signUpDto)
        {
            

              var signUpResultModel = _userService.SignUp(signUpDto);
            var claims = new List<Claim> { new Claim(nameof(SignUpResultModel.Id), signUpResultModel.Id.ToString()) };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            var signUpResultDto = _mapper.Map<SignUpResultModel, SignUpResultDto>(signUpResultModel);
            return Ok(signUpResultDto);
        }
        [HttpPost(nameof(Login))]
        public IActionResult Login(LoginDto loginDto)
        {
        
          var loginResultModel =   _userService.Login(loginDto);
            var claims = new List<Claim> { new Claim(nameof(loginResultModel.Id), loginResultModel.Id.ToString()) };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
       var loginResultDto =      _mapper.Map<LoginResultModel, LoginResultDto>(loginResultModel);
            return Ok(loginResultDto);
        }
        [HttpPost(nameof(IsCategoryAdmin))]
        public async Task<IActionResult> IsCategoryAdmin(long categoryId)
        {
            return Ok(await _userService.IsCategoryAdmin(categoryId));
        }
    }
}
