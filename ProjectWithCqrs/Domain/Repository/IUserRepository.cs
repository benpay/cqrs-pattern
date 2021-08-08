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
        UserModel InsertUser(string firstName, string lastName, string address);
        UserModel UpdateByName(Guid id, string firstName, string lastName, string address);
        UserModel DeleteUser(Guid id);
    }
}