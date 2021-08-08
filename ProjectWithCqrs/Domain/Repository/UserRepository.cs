﻿using CoreProject.Domain.Database;
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
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public UserModel InsertUser(UserModel user)
        {
            try
            {
                UserModel result;

                using (var db = new Context())
                {
                    var address = user.Address.FirstOrDefault();
                    user.Id = Guid.NewGuid();
                    address.Id = Guid.NewGuid();
                    address.UserId = user.Id;

                    db.Addresses.Add(address);
                    db.Users.Add(user);
                    db.SaveChanges();
                    result = user;
                }
                return result;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public UserModel UpdateByName(UserModel user)
        {
            try
            {
                using (var db = new Context())
                {
                    var address = user.Address.FirstOrDefault();
                    address.Id = Guid.NewGuid();
                    address.UserId = user.Id;

                    db.Addresses.Add(address);
                    db.Users.Update(user);
                    db.SaveChanges();
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public UserModel DeleteUser(UserModel user)
        {
            try
            {
                using (var db = new Context())
                {
                    //db.Addresses.Remove(user.Address);
                    db.Remove(user);
                    db.SaveChanges();
                }
                return user;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
