using ServicesLayer.DTO.NewsFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.DTO.News
{
    public class AddNewsDto
    {
        public long CategoryId { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }

        public IEnumerable<AddNewsFileDto> Images { get; set; }

        public IEnumerable<AddNewsFileDto> Attachments { get; set; }
        public IEnumerable<AddNewsFileDto> Videos { get; set; }
    }
}
