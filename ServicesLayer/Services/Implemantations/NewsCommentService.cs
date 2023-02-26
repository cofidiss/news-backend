using AutoMapper;
using DomainLayer.Entity.Postgre;
using DomainLayer.Model.NewsComment;
using RepositoryLayer.RepositoryPattern.Interfaces;
using ServicesLayer.DTO;
using ServicesLayer.DTO.NewsComment;
using ServicesLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services.Implemantations
{
    public class NewsCommentService : INewsCommentService
    {
        INewsCommentRepository _newsCommentRepository { get;}
        IMapper _mapper { get; }
        public NewsCommentService(INewsCommentRepository newsCommentRepository, IMapper mapper)
        {
            _newsCommentRepository = newsCommentRepository;
            _mapper = mapper;   
        }
        public async Task<ResponseDto> Add(AddNewsCommentDto addNewsCommentDto)
        {
            var responseDto = new ResponseDto() { HasError = false, Message = "Comment is added." };
            var addNewsCommentModel = _mapper.Map<AddNewsCommentDto, AddNewsCommentModel> (addNewsCommentDto);

            var newsCommentEntityToInsert = new NewsCommentEntity() {Id=0,NewsId=addNewsCommentModel.NewsId,
            Comment= addNewsCommentModel.Comment,CreatedBy= -1 ,CreationDate=DateTime.Now,LastUpdateDate=null,LastUpdatedBy=null
            };
           
           
          await  _newsCommentRepository.InsertAsync(newsCommentEntityToInsert);

            return responseDto;


        }
    }
}
