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
    public class UsersRepository : IUsersRepository
    {
        public PostgreNewsDbContext _dbContext { get; set; }
        public UsersRepository(PostgreNewsDbContext postgreNewsDbContext)
        {
            _dbContext = postgreNewsDbContext;
        }
        public ResponseModel SignUp(SignUpModel signUpModel)
        {
          var responseModel =  new ResponseModel() { HasError = false, Message = "Kullanıcı eklenmiştir." };
            var usersEntityToInsert =   new UserEntity() {BirthDate= signUpModel.BirthDate,CreatedBy=-1,CreationDate=DateTime.Now,
          Email=signUpModel.Email,LastUpdateDate =null,LastUpdatedBy=null,UserName= signUpModel.UserName,Id=0,Password= signUpModel.Password
          };
            _dbContext.Add(usersEntityToInsert);
            _dbContext.SaveChanges();
            return responseModel;
           
        }
    }
}
