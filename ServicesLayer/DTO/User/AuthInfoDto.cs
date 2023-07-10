using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.DTO.User
{
    public class AuthInfoDto
    {
        public string Initials { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
