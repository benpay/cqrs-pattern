using CoreProject.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject.Commands
{
    public class DeleteAddressCommandClass
    {
        public record DeleteAddressCommand(Guid id) : IRequest<AddressesHistoryModel>;
    }
}
