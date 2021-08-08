using CoreProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreProject.Domain.Repository
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> All();
        UserModel GetById(Guid id);
        UserModel InsertUser(UserModel user);
        UserModel UpdateByName(UserModel user);
        UserModel DeleteUser(UserModel user);
    }
}