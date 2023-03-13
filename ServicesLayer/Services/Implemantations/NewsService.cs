using AutoMapper;
using DomainLayer.Model;
using DomainLayer.Model.News;
using RepositoryLayer.RepositoryPattern.Interfaces;
using ServicesLayer.DTO;
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

        public async Task<ResponseDto> AddNews(AddNewsDto addNewsDto)
        {
            var addNewsModel = _mapper.Map<AddNewsDto, AddNewsModel>(addNewsDto);
            var responseModel =  await _newsRepository.AddNews(addNewsModel);
            var responseDto = _mapper.Map<ResponseModel, ResponseDto>(responseModel);
            return responseDto;

        }
    }
}
