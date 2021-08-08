using CoreProject.Domain.Models;
using CoreProject.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CoreProject.Commands.DeleteAddressCommandClass;
using static CoreProject.Commands.InsertAddressCommandClass;
using static CoreProject.Commands.UpdateAddressCommandClass;

namespace ApiProject.Controller
{
    [ApiController]
    [Route("[controller]/address")]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<AddressesHistoryModel>> Get()
        {
            return await _mediator.Send(new GetAddressesListQuery());
        }

        [HttpGet("{id}")]
        public async Task<AddressesHistoryModel> Get(Guid id)
        {
            return await _mediator.Send(new GetAddressByIdQuery(id));
        }

        [HttpPost("{userId}/{address}")]
        public async Task<AddressesHistoryModel> Post(Guid userId, string address)
        {
            return await _mediator.Send(new InsertAddressCommand(userId, address));
        }

        [HttpPatch("{id}/{userId}/{address}")]
        public async Task<AddressesHistoryModel> Update(Guid id, Guid userId, string address)
        {
            return await _mediator.Send(new UpdateAddressCommand(id, userId, address));
        }

        [HttpDelete]
        public async Task<AddressesHistoryModel> Delete([FromBody] Guid id)
        {
            return await _mediator.Send(new DeleteAddressCommand(id));
        }
    }
}
