using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.DTO.User
{
    public class LoginResultDto
    {
        public long Id { get; set; }
        public bool HasError { get; set; }
        public string Message { get; set; }
    }
}
