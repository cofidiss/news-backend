using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity.Postgre
{
    public class NewsEntity:BaseEntity
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Text { get; set; }
        public string Header { get; set; }

    }
}
