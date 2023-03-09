using ServicesLayer.DTO.NewsFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.DTO.News
{
    public  class NewsAndMetaDataDto
    {
        public long Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public IEnumerable<NewsFileMetaDataDto> Images { get; set; }
        public IEnumerable<NewsFileMetaDataDto> Attachments { get; set; }
        public IEnumerable<NewsFileMetaDataDto> Videos { get; set; }
    }
}
