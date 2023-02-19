using ServicesLayer.DTO;
using ServicesLayer.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services.Interfaces
{
    public interface IUserService
    {
        ResponseDto SignUp(SignUpDto signUpDto);
        ResponseDto Login(LoginDto loginDto);

    }
}
