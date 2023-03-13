using AutoMapper;
using DomainLayer.Model.NewsFile;
using ServicesLayer.DTO.NewsFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Profiles
{
    public class NewsFileProfile : Profile
    {
        public NewsFileProfile()
        
            {
                CreateMap<NewsFileMetaDataModel, NewsFileMetaDataDto>();
            CreateMap< AddNewsFileDto,AddNewsFileModel>();
            
            }
    }
}
