using CoreProject.Domain.Models;
using CoreProject.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static CoreProject.Commands.DeleteUserCommandClass;

namespace CoreProject.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, UserModel>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<UserModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userRepository.DeleteUser(request.value));
        }
    }
}
