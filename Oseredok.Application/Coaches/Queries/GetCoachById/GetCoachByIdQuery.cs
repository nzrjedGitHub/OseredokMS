using ErrorOr;
using MediatR;
using Oseredok.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oseredok.Application.Coaches.Queries.GetCoachById
{
    public record GetCoachByIdQuery(
        Guid Id) : IRequest<ErrorOr<Coach>>;
}