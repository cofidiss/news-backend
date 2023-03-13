using DomainLayer.Model.NewsFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model.News
{
    public class AddNewsModel
    {
        public long CategoryId { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }

        public IEnumerable<AddNewsFileModel> Images { get; set; }

        public IEnumerable<AddNewsFileModel> Attachments { get; set; }
        public IEnumerable<AddNewsFileModel> Videos { get; set; }
    }
}
