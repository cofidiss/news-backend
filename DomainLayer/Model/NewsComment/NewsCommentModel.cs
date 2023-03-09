using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model.NewsComment
{
    public class NewsCommentModel
    {

        public string Comment { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
