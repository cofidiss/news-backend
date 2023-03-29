using DomainLayer.Model.News;
using ServicesLayer.DTO;
using ServicesLayer.DTO.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services.Interfaces
{
    public interface INewsService
    {

        Task<NewsAndMetaDataDto> GetNewsAndMetaData(long id);
        Task<ResponseDto> AddNews(AddNewsDto addNewsDto);
        Task<IEnumerable<NewsListForCategoryDto>> GetNewsListForCategory(long categoryId);
        Task<ResponseDto> DeleteNewsAndFiles(long newsId);
    }
}
