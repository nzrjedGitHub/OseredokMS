using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oseredok.Application.Admins.Queries.GetAdminById;
using Oseredok.Application.Admins.Queries.GetAllAdmins;
using Oseredok.Application.Admins.Queries.GetByUserId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oseredok.Api.Controllers
{
    [Route("/admin")]
    [AllowAnonymous]
    public class AdminController : ApiController
    {
        private readonly ISender _mediator;

        private readonly IMapper _mapper;

        public AdminController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetAdminByIdQuery(id);
            var result = await _mediator.Send(query);

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }

        [HttpGet("getByUserId/{id}")]
        public async Task<IActionResult> GetByUserId(Guid id)
        {
            var query = new GetAdminByUserIdQuery(id);
            var result = await _mediator.Send(query);

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllAdminsQuery();
            var result = await _mediator.Send(query);

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }
    }
}