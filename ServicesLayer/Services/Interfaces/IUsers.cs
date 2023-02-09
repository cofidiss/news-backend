using ServicesLayer.DTO;
using ServicesLayer.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services.Interfaces
{
    public interface IUsers
    {
        ResponseDto SignUp(SignUpDto signUpDto);

    }
}
