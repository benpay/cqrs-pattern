using CoreProject.Domain.Models;
using CoreProject.Domain.Repository;
using CoreProject.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoreProject.Handlers
{
    public class GetAddressesListHandler : IRequestHandler<GetAddressesListQuery, IEnumerable<AddressesHistoryModel>>
    {
        private readonly IAddessesRepository _addessesRepository;

        public GetAddressesListHandler(IAddessesRepository addessesRepository)
        {
            _addessesRepository = addessesRepository;
        }
        public Task<IEnumerable<AddressesHistoryModel>> Handle(GetAddressesListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_addessesRepository.All());
        }
    }
}
