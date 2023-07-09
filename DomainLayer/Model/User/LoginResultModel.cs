using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model.User
{
    public class LoginResultModel
    {
        public long Id { get; set; }
        public bool HasError { get; set; }
        public string Message { get; set; }
    }
}
