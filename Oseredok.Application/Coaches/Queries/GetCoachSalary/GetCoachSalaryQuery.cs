using ErrorOr;
using MediatR;
using Oseredok.Shared.DTOs.Coach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oseredok.Application.Coaches.Queries.GetCoachSalary
{
    public record GetCoachSalaryQuery(Guid Id, DateTime FromDate, DateTime TillDate) : IRequest<ErrorOr<CoachSalaryDto>>;
}