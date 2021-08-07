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
    public class GetUserListHandler : IRequestHandler<GetUsersListQuery, IEnumerable<UserModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserListHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<IEnumerable<UserModel>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userRepository.All());
        }
    }
}
