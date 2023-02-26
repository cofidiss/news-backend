using DomainLayer.Entity.Postgre;
using DomainLayer.Model.NewsComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepositoryPattern.Interfaces
{
    public interface INewsCommentRepository : IGenericRepository<NewsCommentEntity>
    {
        Task<IEnumerable<NewsCommentModel>> GetCommentsForNews(long newsId);
    }
}
