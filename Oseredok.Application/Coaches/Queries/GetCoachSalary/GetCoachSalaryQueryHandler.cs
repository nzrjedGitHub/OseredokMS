using ErrorOr;
using MapsterMapper;
using MediatR;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Shared.DTOs.Coach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oseredok.Application.Coaches.Queries.GetCoachSalary
{
    public class GetCoachSalaryQueryHandler : IRequestHandler<GetCoachSalaryQuery, ErrorOr<CoachSalaryDto>>
    {
        private readonly ICoachRepository _coachRepository;
        private readonly IMapper _mapper;

        public GetCoachSalaryQueryHandler(ICoachRepository coachRepository, IMapper mapper)
        {
            _coachRepository = coachRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<CoachSalaryDto>> Handle(GetCoachSalaryQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var salary = await _coachRepository.GetCoachSalary(_mapper.Map<GetCoachSalaryDto>(query));
            return salary;
        }
    }
}