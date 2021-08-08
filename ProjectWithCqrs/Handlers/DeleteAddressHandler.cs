using CoreProject.Domain.Models;
using CoreProject.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static CoreProject.Commands.DeleteAddressCommandClass;
using static CoreProject.Commands.DeleteUserCommandClass;

namespace CoreProject.Handlers
{
    public class DeleteAddressHandler : IRequestHandler<DeleteAddressCommand, AddressesHistoryModel>
    {
        private readonly IAddessesRepository _addessesRepository;

        public DeleteAddressHandler(IAddessesRepository addessesRepository)
        {
            _addessesRepository = addessesRepository;
        }
        public Task<AddressesHistoryModel> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_addessesRepository.DeleteAddress(request.id));
        }
    }
}
