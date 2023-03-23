using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model.Category
{
    public class CategoriesForNavBarModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CategoriesForNavBarModel> Children { get; set; }
    }
}
