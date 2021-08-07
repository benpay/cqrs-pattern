using CoreProject.Domain.Models;
using CoreProject.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static CoreProject.Commands.InsertUserCommandClass;

namespace CoreProject.Handlers
{
    public class InsertUserHandler : IRequestHandler<InsertUserCommand, UserModel>
    {
        private readonly IUserRepository _userRepository;

        public InsertUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<UserModel> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userRepository.InsertPerson(request.user));
        }
    }
}
