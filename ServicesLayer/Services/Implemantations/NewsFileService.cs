using AutoMapper;
using DomainLayer.Entity.Postgre;
using RepositoryLayer.RepositoryPattern.Interfaces;
using ServicesLayer.DTO.NewsFile;
using ServicesLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services.Implemantations
{
    public class NewsFileService: INewsFileService
    {
        public INewsFileRepository _newsFileRepository { get; set; }
        public IMapper _mapper { get; set; }
        public NewsFileService(INewsFileRepository newsFileRepository, IMapper mapper)
        {
            _newsFileRepository = newsFileRepository;
            _mapper = mapper;   
        }

        public async Task<NewsFileDto> Get(long id)
        {
            var newsFileEntityList =  await _newsFileRepository.FilterAsync(x => x.Id.Equals(id));
          var newsFileEntity =   newsFileEntityList.First();
         //   var bytes = System.IO.File.ReadAllBytes("../ApiLayer/a.jpg");
         //  newsFileEntity.ByteArray = bytes;
         //_newsFileRepository.InsertAsync(newsFileEntity).Wait();
          var newsFileDto =  _mapper.Map<NewsFileEntity, NewsFileDto>(newsFileEntity);
            return newsFileDto;
        }
    }
}
