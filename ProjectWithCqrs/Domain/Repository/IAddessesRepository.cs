using CoreProject.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoreProject.Domain.Repository
{
    public interface IAddessesRepository
    {
        IEnumerable<AddressesHistoryModel> All();
        AddressesHistoryModel DeleteAddress(AddressesHistoryModel address);
        AddressesHistoryModel GetById(Guid id);
        AddressesHistoryModel GetByUserId(Guid userId);
        AddressesHistoryModel InsertAddress(AddressesHistoryModel address);
        AddressesHistoryModel UpdateAddress(AddressesHistoryModel address);
    }
}