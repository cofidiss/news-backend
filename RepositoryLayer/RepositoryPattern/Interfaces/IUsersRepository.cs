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
        SignUpResultModel SignUp(SignUpModel signUpModel);
        LoginResultModel Login(LoginModel loginModel);
    }
}
