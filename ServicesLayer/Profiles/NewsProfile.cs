using AutoMapper;
using DomainLayer.Entity.Postgre;
using DomainLayer.Model.News;
using DomainLayer.Model.NewsFile;
using ServicesLayer.DTO.News;
using ServicesLayer.DTO.NewsFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Profiles
{
    public class NewsProfile:Profile
    {

        public NewsProfile()
        {
            CreateMap<NewsAndMetaDataModel, NewsAndMetaDataDto>();
            CreateMap<NewsFileEntity, NewsFileDto>();
            CreateMap<AddNewsFileDto, AddNewsFileModel>();
            CreateMap<AddNewsDto, AddNewsModel>();


        }
    

        
    }
}
