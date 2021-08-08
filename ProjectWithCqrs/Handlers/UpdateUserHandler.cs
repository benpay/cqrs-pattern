using CoreProject.Domain.Models;
using CoreProject.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static CoreProject.Commands.UpdateUserCommandClass;

namespace CoreProject.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserModel>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<UserModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userRepository.UpdateByName(request.id, request.firstName, request.lastName, request.address));
        }
    }
}
    