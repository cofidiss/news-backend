using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.DTO.News
{
    public class NewsListForCategoryDto
    {
        public long Id { get; set; }
        public string Header { get; set; }
        public DateTime UploadDate { get; set; }
        public bool IsDeletable { get; set; }
    }
}
