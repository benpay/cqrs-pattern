using CoreProject.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject.Commands
{
    public class UpdateUserCommandClass
    {
        public record UpdateUserCommand(Guid id, string firstName, string lastName, string address) : IRequest<UserModel>;
    }
}
