using DomainLayer.Model.User;
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
        LoginResultModel Login(LoginDto loginDto);
        Task<bool> IsCategoryAdmin(long categoryId);
    }
}
