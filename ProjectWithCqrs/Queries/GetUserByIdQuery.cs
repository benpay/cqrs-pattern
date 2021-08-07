using CoreProject.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject.Queries
{
    public record GetUserByIdQuery(Guid Id) : IRequest<UserModel>;
}
