using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model.NewsComment
{
    public class AddNewsCommentModel
    {
        public long NewsId { get; set; }
        public string Comment { get; set; }

    }
}
