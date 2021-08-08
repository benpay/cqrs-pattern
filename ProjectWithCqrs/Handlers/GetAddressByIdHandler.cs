using CoreProject.Domain.Models;
using CoreProject.Domain.Repository;
using CoreProject.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CoreProject.Handlers
{
    public class GetAddressByIdHandler : IRequestHandler<GetAddressByIdQuery, AddressesHistoryModel>
    {
        private readonly IAddessesRepository _addessesRepository;

        public GetAddressByIdHandler(IAddessesRepository addessesRepository)
        {
            _addessesRepository = addessesRepository;
        }
        public Task<AddressesHistoryModel> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_addessesRepository.GetById(request.Id));
        }
    }
}
