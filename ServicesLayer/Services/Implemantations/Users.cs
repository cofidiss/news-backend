using AutoMapper;
using DomainLayer.Model;
using DomainLayer.Model.Users;
using RepositoryLayer.RepositoryPattern.Interfaces;
using ServicesLayer.DTO;
using ServicesLayer.DTO.Users;
using ServicesLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services.Implemantations
{
    public class Users : IUsers
    {
        public IUsersRepository _usersRepository { get; set; }
        public IMapper _mapper { get; set; }
        public Users(IUsersRepository usersRepository, IMapper mapper)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;

        }
        public ResponseDto SignUp(SignUpDto signUpDto)
        {

            var signUpModel = _mapper.Map<SignUpDto, SignUpModel>(signUpDto);
            var responseModel = _usersRepository.SignUp(signUpModel);
         var responseDto =   _mapper.Map<ResponseModel, ResponseDto > (responseModel);
            return responseDto;
        }
    }
}
