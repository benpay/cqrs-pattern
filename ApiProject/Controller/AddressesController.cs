using CoreProject.Domain.Models;
using CoreProject.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CoreProject.Commands.DeleteUserCommandClass;
using static CoreProject.Commands.InsertAddressCommandClass;
using static CoreProject.Commands.InsertUserCommandClass;
using static CoreProject.Commands.UpdateUserCommandClass;

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

        //[HttpGet("{id}")]
        //public async Task<UserModel> Get(Guid id)
        //{
        //    return await _mediator.Send(new GetUserByIdQuery(id));
        //}

        [HttpPost]
        public async Task<AddressesHistoryModel> Post([FromBody] AddressesHistoryModel value)
        {
            return await _mediator.Send(new InsertAddressCommand(value));
        }

        //[HttpPatch]
        //public async Task<UserModel> Update([FromBody] UserModel value)
        //{
        //    return await _mediator.Send(new UpdateUserCommand(value));
        //}

        //[HttpDelete]
        //public async Task<UserModel> Delete([FromBody] UserModel value)
        //{
        //    return await _mediator.Send(new DeleteUserCommand(value));
        //}
    }
}
