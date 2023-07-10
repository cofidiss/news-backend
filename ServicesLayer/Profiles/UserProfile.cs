using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entity.Postgre;
using ServicesLayer.DTO.User;
using DomainLayer.Model.User;

namespace ServicesLayer.Profiles
{
    public class UserProfile:Profile
    {

        public UserProfile()
        {
            CreateMap<SignUpDto, SignUpModel> ();
            CreateMap<LoginDto, LoginModel>();
            CreateMap<LoginResultModel, LoginResultDto>();
            CreateMap<SignUpResultModel, SignUpResultDto>();
            CreateMap<AuthInfoModel, AuthInfoDto>();
            
        }
    }
}
