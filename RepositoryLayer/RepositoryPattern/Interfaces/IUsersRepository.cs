using DomainLayer.Model;
using DomainLayer.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepositoryPattern.Interfaces
{
    public interface IUsersRepository
    {
      ResponseModel  SignUp(SignUpModel signUpModel);
    }
}
