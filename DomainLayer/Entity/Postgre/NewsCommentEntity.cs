using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity.Postgre
{
    public class NewsCommentEntity: BaseEntity
    {
        public long Id { get; set; }

        public long NewsId { get; set; }
        public string Comment { get; set; }

     

    }
}
