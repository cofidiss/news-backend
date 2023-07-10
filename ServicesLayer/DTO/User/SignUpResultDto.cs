using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.DTO.User
{
    public class SignUpResultDto
    {

        public bool HasError { get; set; }
        public string Message { get; set; }
    }
}
