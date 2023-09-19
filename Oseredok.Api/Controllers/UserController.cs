using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oseredok.Application.Users.Commands.Delete;
using Oseredok.Application.Users.Commands.Update;
using Oseredok.Application.Users.Commands.UpdateRole;
using Oseredok.Application.Users.Queries.GetUserById;
using Oseredok.Application.Users.Queries.GetUsersByRole;
using Oseredok.Contracts.Common;
using Oseredok.Contracts.User;

namespace Oseredok.Api.Controllers
{
    [Route("/user")]
    [AllowAnonymous]
    public class UserController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public UserController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("updateRole")]
        public async Task<IActionResult> UpdateRole([FromQuery] UserUpdateRoleRequest request)
        {
            var command = _mapper.Map<UserUpdateRoleCommand>(request);
            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UserUpdateRequest request)
        {
            var command = _mapper.Map<UserUpdateCommand>(request);
            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query);

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }

        [HttpGet("getAllByRole/{role}")]
        public async Task<IActionResult> GetAllByRole(string role)
        {
            var query = new GetUsersByRoleQuery(role);
            var result = await _mediator.Send(query);

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteRequest request)
        {
            var command = _mapper.Map<UserDeleteCommand>(request);
            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }
    }
}