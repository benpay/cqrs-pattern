using CoreProject.Domain.Models;
using CoreProject.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static CoreProject.Commands.UpdateAddressCommandClass;
using static CoreProject.Commands.UpdateUserCommandClass;

namespace CoreProject.Handlers
{
    public class UpdateAddressHandler : IRequestHandler<UpdateAddressCommand, AddressesHistoryModel>
    {
        private readonly IAddessesRepository _addessesRepository;

        public UpdateAddressHandler(IAddessesRepository addessesRepository)
        {
            _addessesRepository = addessesRepository;
        }
        public Task<AddressesHistoryModel> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_addessesRepository.UpdateAddress(request.id, request.userId, request.address));
        }
    }
}
    