using DomainLayer.Entity.Postgre;
using DomainLayer.Model;
using DomainLayer.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepositoryPattern.Interfaces
{
    public interface IUsersRepository: IGenericRepository<UserEntity>
    {
      ResponseModel  SignUp(SignUpModel signUpModel);
        ResponseModel Login(LoginModel loginModel);
    }
}
