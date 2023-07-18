using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity.Postgre
{
    public class CategoryAdminEntity:BaseEntity
    {

        public long Id { get; set; }
        public long UserId { get; set; }
        public long CategoryId { get; set; }
    }
}
