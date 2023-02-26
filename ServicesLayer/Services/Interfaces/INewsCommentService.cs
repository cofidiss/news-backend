using ServicesLayer.DTO;
using ServicesLayer.DTO.NewsComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services.Interfaces
{
    public interface INewsCommentService
    {
        Task<ResponseDto> Add(AddNewsCommentDto addNewsCommentDto);
        Task<ResponseDto> GetCommentsForNews(long newsId);
    }
}
