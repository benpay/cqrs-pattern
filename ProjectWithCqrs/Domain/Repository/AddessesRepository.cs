using CoreProject.Domain.Database;
using CoreProject.Domain.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject.Domain.Repository
{
    public class AddessesRepository : IAddessesRepository
    {
        public IEnumerable<AddressesHistoryModel> All()
        {
            try
            {
                IEnumerable<AddressesHistoryModel> result;

                using (var db = new Context())
                {
                    result = db.Addresses.ToList();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public AddressesHistoryModel GetById(Guid id)
        {
            try
            {
                AddressesHistoryModel result;

                using (var db = new Context())
                {
                    result = db.Addresses.FirstOrDefault(x => x.Id == id);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public AddressesHistoryModel GetByUserId(Guid userId)
        {
            try
            {
                AddressesHistoryModel result;

                using (var db = new Context())
                {
                    result = db.Addresses.FirstOrDefault(x => x.UserId == userId);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public AddressesHistoryModel InsertAddress(Guid userId, string address)
        {
            try
            {
                AddressesHistoryModel result = new AddressesHistoryModel()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Address = address,
                    AddedOnDate = DateTime.Now
                };

                using (var db = new Context())
                {
                    db.Addresses.Add(result);
                    db.SaveChanges();
                }
                return result;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public AddressesHistoryModel UpdateAddress(Guid id, Guid userId, string address)
        {
            try
            {
                AddressesHistoryModel result;
                using (var db = new Context())
                {
                    result = db.Addresses.Where(x => x.Id == id).FirstOrDefault();
                    if (result != null)
                    {
                        result.UserId = userId == Guid.Empty ? result.UserId : userId;
                        result.Address = address == null ? result.Address : address;
                        db.Addresses.Update(result);
                        db.SaveChanges();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public AddressesHistoryModel DeleteAddress(Guid id)
        {
            try
            {
                AddressesHistoryModel result;
                using (var db = new Context())
                {
                    result = db.Addresses.Where(x => x.Id == id).FirstOrDefault();
                    db.Remove(result);
                    db.SaveChanges();
                }
                return result;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
