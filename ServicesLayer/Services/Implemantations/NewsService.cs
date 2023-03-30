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

        public async Task<IEnumerable<NewsListForCategoryDto>> GetNewsListForCategory(long categoryId)
        {
            var newsListForCategoryModelList  = await _newsRepository.GetNewsListForCategory(categoryId);
            var newsListForCategoryDtoList = _mapper.Map< IEnumerable<NewsListForCategoryModel>, IEnumerable<NewsListForCategoryDto>>(newsListForCategoryModelList);
            return newsListForCategoryDtoList;
        }

        public async Task<ResponseDto> DeleteNewsAndFiles(long newsId)
        {
            
            var responseModel = await _newsRepository.DeleteNewsAndFiles(newsId);
            var responseDto = _mapper.Map<ResponseModel, ResponseDto>(responseModel);
            return responseDto;
        }
    }
}
