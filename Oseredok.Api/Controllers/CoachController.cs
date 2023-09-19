using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oseredok.Application.Admins.Queries.GetAdminById;
using Oseredok.Application.Coaches.Queries.GetCoachById;
using Oseredok.Application.Coaches.Queries.GetCoachSalary;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Contracts.Coach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oseredok.Api.Controllers
{
    [Route("/coach")]
    [AllowAnonymous]
    public class CoachController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        private readonly ICoachRepository _coachRepository;

        public CoachController(ISender mediator, IMapper mapper, ICoachRepository coachRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _coachRepository = coachRepository;
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetCoachByIdQuery(id);
            var result = await _mediator.Send(query);

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = _coachRepository.GetAll().Result;

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }

        [HttpGet("getCoachSalary")]
        public async Task<IActionResult> GetCoachSalary([FromQuery] GetCoachSalaryRequest request)
        {
            var query = _mapper.Map<GetCoachSalaryQuery>(request);
            //var query = request.Adapt<GetCoachSalaryQuery>();
            Console.WriteLine(query);
            var result = await _mediator.Send(query);

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }
    }
}