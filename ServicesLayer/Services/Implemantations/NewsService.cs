using AutoMapper;
using DomainLayer.Model.News;
using RepositoryLayer.RepositoryPattern.Interfaces;
using ServicesLayer.DTO.News;
using ServicesLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services.Implemantations
{
    public class NewsService:INewsService
    {
        public INewsRepository _newsRepository { get; set; }
        public IMapper _mapper { get; set; }
        public NewsService(INewsRepository newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
        }

        public async Task<NewsAndMetaDataDto> GetNewsAndMetaData(long id)
        {
         var newsAndMetaDataModel =   await  _newsRepository.GetNewsAndMetaData(id);
        var newsAndMetaDataDto =   _mapper.Map<NewsAndMetaDataModel, NewsAndMetaDataDto > (newsAndMetaDataModel);
            return newsAndMetaDataDto;
        }
    }
}
