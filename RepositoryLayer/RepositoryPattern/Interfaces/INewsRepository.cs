using DomainLayer.Model;
using DomainLayer.Model.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepositoryPattern.Interfaces
{
    public interface INewsRepository
    {
        Task<NewsAndMetaDataModel> GetNewsAndMetaData(long id);
        Task<ResponseModel> AddNews(AddNewsModel addNewsModel);
    }
}
