using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.DTO.Category
{
    public class CategoryListForCRUDDto
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
        public long? ParentId { get; set; }
    }
}
