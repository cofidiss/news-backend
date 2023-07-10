using DomainLayer.Entity.Postgre;
using DomainLayer.Model;
using DomainLayer.Model.User;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.RepositoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepositoryPattern.Implemantations
{
    public class UsersRepository : GenericRepository<UserEntity>,IUsersRepository
    {
        public DbContext _dbContext { get; set; }
        public UsersRepository(PostgreNewsDbContext postgreNewsDbContext):base(postgreNewsDbContext)    
        {
            _dbContext = postgreNewsDbContext;
        }
        public SignUpResultModel SignUp(SignUpModel signUpModel)
        {
          var signUpResultModel =  new SignUpResultModel() { HasError = false, Message = "SignUp is successfull" };

            var userNameCheckQuery = from user in _dbContext.Set<UserEntity>()
                                     where user.UserName == signUpModel.UserName
                                     select user;
            var  userEntities= userNameCheckQuery.ToArray();
            if (userEntities.Length >0)
            {
                signUpResultModel.HasError = true;
                signUpResultModel.Message = $"Username {signUpModel.UserName} already exits.";
                return signUpResultModel;
            }
            var emailCheckQuery = from user in _dbContext.Set<UserEntity>()
                                     where user.Email == signUpModel.Email
                                  select user;
            if (emailCheckQuery.ToArray().Length > 0)
            {
                signUpResultModel.HasError = true;
                signUpResultModel.Message = $"Email {signUpModel.Email} already exits.";
                return signUpResultModel;
            }



            var usersEntityToInsert =   new UserEntity() {BirthDate= signUpModel.BirthDate,CreatedBy=-1,CreationDate=DateTime.Now,
          Email=signUpModel.Email,LastUpdateDate =null,LastUpdatedBy=null,UserName= signUpModel.UserName,Id=0,Password= signUpModel.Password
          };
            _dbContext.Add(usersEntityToInsert);
            _dbContext.SaveChanges();
            signUpResultModel.Id = usersEntityToInsert.Id;
            return signUpResultModel;
           
        }

        public LoginResultModel Login(LoginModel loginModel)
        {
            var loginResultModel = new LoginResultModel() { HasError = true,Message="An Error occured during login" };

            var loginCheckQuery = from user in _dbContext.Set<UserEntity>()
                                     where user.UserName == loginModel.UserName && user.Password == loginModel.Password
                                     select user;
        var userEntities =   loginCheckQuery.ToArray();
            if (userEntities.Length == 0)
            {
                loginResultModel.HasError = true;
                loginResultModel.Message = $"Could not find the user {loginModel.UserName}";
                return loginResultModel;
            }
            if (userEntities.Length != 0)
            {
                loginResultModel.HasError = false;
                loginResultModel.Id= userEntities.First().Id;
                loginResultModel.Message = "Login Succesfull";
                return loginResultModel;
            }
            return loginResultModel;


        }

        public AuthInfoModel GetAuthInfo(long userId)
        {
            var userEntityQuery = from user in _dbContext.Set<UserEntity>()
                                  where user.Id == userId
                                  select user;
            var userEntity = userEntityQuery.ToArray().First();
            var authInfoModel = new AuthInfoModel();
            authInfoModel.Initials = userEntity.UserName;
            authInfoModel.IsAuthenticated = true;
            return authInfoModel;

        }
    }
}
