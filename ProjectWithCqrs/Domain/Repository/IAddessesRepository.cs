using CoreProject.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoreProject.Domain.Repository
{
    public interface IAddessesRepository
    {
        IEnumerable<AddressesHistoryModel> All();
        AddressesHistoryModel DeleteAddress(Guid id);
        AddressesHistoryModel GetById(Guid id);
        AddressesHistoryModel GetByUserId(Guid userId);
        AddressesHistoryModel InsertAddress(Guid userId, string address);
        AddressesHistoryModel UpdateAddress(Guid id, Guid userId, string address);
    }
}