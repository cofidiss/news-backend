using AutoMapper;
using DomainLayer.Entity.Postgre;
using DomainLayer.Model.News;
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
            
        }
    

        
    }
}
