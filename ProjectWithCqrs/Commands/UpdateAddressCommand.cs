using CoreProject.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject.Commands
{
    public class UpdateAddressCommandClass
    {
        public record UpdateAddressCommand(Guid id, Guid userId, string address) : IRequest<AddressesHistoryModel>;
    }
}
