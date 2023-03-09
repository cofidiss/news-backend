using DomainLayer.Model.NewsFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model.News
{
    public class NewsAndMetaDataModel
    {
        public long Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public IEnumerable<NewsFileMetaDataModel> Images { get; set; }
        public IEnumerable<NewsFileMetaDataModel> Attachments { get; set; }
        public IEnumerable<NewsFileMetaDataModel> Videos { get; set; }
    }
}
