using DomainLayer.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model.NewsFile
{
    public class AddNewsFileModel
    {
        public long NewsId { get; set; }
        public string Name { get; set; }
        public byte[] ByteArray { get; set; }

    }
}
