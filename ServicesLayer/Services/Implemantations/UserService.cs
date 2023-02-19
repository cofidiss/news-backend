using AutoMapper;
using DomainLayer.Extension;
using DomainLayer.Model;
using DomainLayer.Model.User;
using RepositoryLayer.RepositoryPattern.Interfaces;
using ServicesLayer.DTO;
using ServicesLayer.DTO.User;
using ServicesLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services.Implemantations
{
    public class UserService : IUserService
    {
        public IUsersRepository _usersRepository { get; set; }
        public IMapper _mapper { get; set; }
        public UserService(IUsersRepository usersRepository, IMapper mapper)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;

        }
        public ResponseDto SignUp(SignUpDto signUpDto)
        {

            var signUpModel = _mapper.Map<SignUpDto, SignUpModel>(signUpDto);

            signUpModel.Password = signUpModel.Password.GetHashAsHEXString();  
            var responseModel = _usersRepository.SignUp(signUpModel);
         var responseDto =   _mapper.Map<ResponseModel, ResponseDto > (responseModel);
            return responseDto;
        }

        public ResponseDto Login(LoginDto loginDto)
        {
            var loginModel = _mapper.Map<LoginDto, LoginModel>(loginDto);

            loginModel.Password = loginModel.Password.GetHashAsHEXString();
            var responseModel = _usersRepository.Login(loginModel);
            var responseDto = _mapper.Map<ResponseModel, ResponseDto>(responseModel);
            return responseDto;
        }
    }
}
