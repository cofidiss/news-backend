using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.DTO.NewsFile
{
    public class AddNewsFileDto
    {
        public long NewsId { get; set; }
        public string Name { get; set; }
        public byte[] ByteArray { get; set; }
    }
}
