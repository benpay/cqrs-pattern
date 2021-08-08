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

        public AddressesHistoryModel InsertAddress(AddressesHistoryModel address)
        {
            try
            {
                AddressesHistoryModel result;

                using (var db = new Context())
                {
                    address.Id = Guid.NewGuid();
                    db.Addresses.Add(address);
                    db.SaveChanges();
                    result = address;
                }
                return address;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public AddressesHistoryModel UpdateAddress(AddressesHistoryModel address)
        {
            try
            {
                using (var db = new Context())
                {
                    db.Addresses.Update(address);
                    db.SaveChanges();
                }
                return address;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public AddressesHistoryModel DeleteAddress(AddressesHistoryModel address)
        {
            try
            {
                using (var db = new Context())
                {
                    db.Remove(address);
                    db.SaveChanges();
                }
                return address;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
