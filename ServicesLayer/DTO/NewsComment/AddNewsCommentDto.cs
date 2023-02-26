using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.DTO.NewsComment
{
    public class AddNewsCommentDto
    {
        public long NewsId { get; set; }
        public string Comment { get; set; }

    }
}
