using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model.Category
{
    public class CategoryListForCRUDModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
    }
}
