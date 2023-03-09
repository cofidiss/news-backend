using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity.Postgre
{
    public class NewsFileEntity : BaseEntity
    {
        public long Id { get; set; }
        public long NewsId { get; set; }
        public long Type { get; set; }
        public byte[] ByteArray { get; set; }
        public string Name { get; set; }
    }
}
