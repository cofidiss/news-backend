using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class ResponseModel
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
    }
}
