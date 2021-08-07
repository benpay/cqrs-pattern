using CoreProject.Domain.Models;
using CoreProject.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CoreProject.Commands.DeleteUserCommandClass;
using static CoreProject.Commands.InsertUserCommandClass;

namespace ApiProject.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<UserModel>> Get()
        {
            return await _mediator.Send(new GetUsersListQuery());
        }

        [HttpGet("{id}")]
        public async Task<UserModel> Get(Guid id)
        {
            return await _mediator.Send(new GetUserByIdQuery(id));
        }

        [HttpPost]
        public async Task<UserModel> Post([FromBody] UserModel value)
        {
            return await _mediator.Send(new InsertUserCommand(value));
        }

        [HttpDelete]
        public async Task<UserModel> Delete([FromBody] UserModel value)
        {
            return await _mediator.Send(new DeleteUserCommand(value));
        }
    }
}
