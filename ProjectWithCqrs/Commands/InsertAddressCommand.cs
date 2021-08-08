using CoreProject.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject.Commands
{
    public class InsertAddressCommandClass
    {
        public record InsertAddressCommand(Guid userId, string address) : IRequest<AddressesHistoryModel>;
    }
}
