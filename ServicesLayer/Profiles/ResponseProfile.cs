using AutoMapper;
using DomainLayer.Model;
using ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Profiles
{
    public class ResponseProfile:Profile
    {

        public ResponseProfile()
        {
            CreateMap<ResponseModel, ResponseDto>();

        }
    }
}
