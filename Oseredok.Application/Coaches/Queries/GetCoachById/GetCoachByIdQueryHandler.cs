using ErrorOr;
using MediatR;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oseredok.Application.Coaches.Queries.GetCoachById
{
    public class GetCoachByIdQueryHandler : IRequestHandler<GetCoachByIdQuery, ErrorOr<Coach>>
    {
        private readonly ICoachRepository _coachRepository;

        public GetCoachByIdQueryHandler(ICoachRepository coachRepository)
        {
            _coachRepository = coachRepository;
        }

        public async Task<ErrorOr<Coach>> Handle(GetCoachByIdQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var coach = await _coachRepository.GetById(query.Id);
            return coach;
        }
    }
}