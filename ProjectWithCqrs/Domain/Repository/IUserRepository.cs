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
        UserModel InsertPerson(UserModel user);
        UserModel DeletePerson(UserModel user);
    }
}