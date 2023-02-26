using AutoMapper;
using DomainLayer.Model;
using DomainLayer.Model.NewsComment;
using ServicesLayer.DTO;
using ServicesLayer.DTO.NewsComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Profiles
{
    public class NewsCommentProfile:Profile
    {

        public NewsCommentProfile()
        {
            CreateMap<AddNewsCommentDto, AddNewsCommentModel>();
        }
    }
}
