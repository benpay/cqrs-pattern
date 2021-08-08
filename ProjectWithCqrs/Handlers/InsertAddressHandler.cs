using CoreProject.Domain.Models;
using CoreProject.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static CoreProject.Commands.InsertAddressCommandClass;

namespace CoreProject.Handlers
{
    public class InsertAddressHandler : IRequestHandler<InsertAddressCommand, AddressesHistoryModel>
    {
        private readonly IAddessesRepository _addressesRepository;

        public InsertAddressHandler(IAddessesRepository addressesRepository)
        {
            _addressesRepository = addressesRepository;
        }
        public Task<AddressesHistoryModel> Handle(InsertAddressCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_addressesRepository.InsertAddress(request.userId, request.address));
        }
    }
}
