using AutoMapper;
using DomainLayer.Extension;
using DomainLayer.Model;
using DomainLayer.Model.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using RepositoryLayer.RepositoryPattern.Interfaces;
using ServicesLayer.DTO;
using ServicesLayer.DTO.User;
using ServicesLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services.Implemantations
{
    public class UserService : IUserService
    {
        public IUsersRepository _usersRepository { get; set; }
        public IMapper _mapper { get; set; }
        IHttpContextAccessor _httpContextAccessor { get; set; }
        public UserService(IUsersRepository usersRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
            _httpContextAccessor = httpContextAccessor;

        }
        public SignUpResultModel SignUp(SignUpDto signUpDto)
        {

            var signUpModel = _mapper.Map<SignUpDto, SignUpModel>(signUpDto);

            signUpModel.Password = signUpModel.Password.GetHashAsHEXString();  
            var signUpResultModel = _usersRepository.SignUp(signUpModel);

            return signUpResultModel;
        }

        public LoginResultModel Login(LoginDto loginDto)
        {
            var loginModel = _mapper.Map<LoginDto, LoginModel>(loginDto);
           
            loginModel.Password = loginModel.Password.GetHashAsHEXString();
            var loginResultModel = _usersRepository.Login(loginModel);
          
           
            return loginResultModel;
        }

        public async Task<bool> IsCategoryAdmin(long categoryId)
        {
            //return false;
            return true;
        }
    }
}
