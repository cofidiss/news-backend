using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.DTO.Category
{
    public class CategoriesForNavBarDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CategoriesForNavBarDto> Children { get; set; }
    }
}
