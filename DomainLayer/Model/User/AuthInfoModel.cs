using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model.User
{
    public class AuthInfoModel
    {
        public string Initials { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
