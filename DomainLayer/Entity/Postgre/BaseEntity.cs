using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity.Postgre
{
    public abstract class BaseEntity
    {
        public DateTime? LastUpdateDate { get; set; }
        public long? LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public long CreatedBy { get; set; }
    }
}
