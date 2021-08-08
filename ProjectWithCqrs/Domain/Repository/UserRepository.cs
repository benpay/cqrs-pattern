using CoreProject.Domain.Database;
using CoreProject.Domain.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject.Domain.Repository
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<UserModel> All()
        {
            try
            {
                IEnumerable<UserModel> result;

                using (var db = new Context())
                {
                    result = db.Users.ToList();
                    foreach (var user in result)
                    {
                        user.Address = db.Addresses.Where(x => x.UserId == user.Id).ToList();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public UserModel GetById(Guid id)
        {
            try
            {
                UserModel result;

                using (var db = new Context())
                {
                    result = db.Users.FirstOrDefault(x => x.Id == id);
                    if (result != null)
                    {
                        result.Address = db.Addresses.Where(x => x.UserId == result.Id).ToList();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public UserModel InsertUser(string firstName, string lastName, string address)
        {
            try
            {
                UserModel user = new();
                using (var db = new Context())
                {

                    user.Id = Guid.NewGuid();
                    user.FirstName = firstName;
                    user.LastName = lastName;

                    AddressesHistoryModel userAddress = new()
                    {
                        Id = Guid.NewGuid(),
                        UserId = user.Id,
                        Address = address,
                        AddedOnDate = DateTime.Now
                    };

                    db.Addresses.Add(userAddress);
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                return GetById(user.Id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public UserModel UpdateByName(Guid id, string firstName, string lastName, string address)
        {
            try
            {
                using (var db = new Context())
                {
                    var user = db.Users.Where(x => x.Id == id).FirstOrDefault();
                    user.FirstName = firstName ?? user.FirstName;
                    user.LastName = lastName ?? user.LastName;

                    AddressesHistoryModel userAddress = new()
                    {
                        Id = Guid.NewGuid(),
                        UserId = user.Id,
                        Address = address,
                        AddedOnDate = DateTime.Now
                    };

                    db.Addresses.Add(userAddress);
                    db.Users.Update(user);
                    db.SaveChanges();
                }
                return GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public UserModel DeleteUser(Guid id)
        {
            try
            {
                UserModel result;
                using (var db = new Context())
                {
                    result = db.Users.Where(x => x.Id == id).FirstOrDefault();
                    db.Remove(result);
                    db.SaveChanges();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
