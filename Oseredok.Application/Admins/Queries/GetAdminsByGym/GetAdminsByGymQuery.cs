using ErrorOr;
using MediatR;
using Oseredok.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oseredok.Application.Admins.Queries.GetAdminsByGym
{
    public record GetAdminsByGymQuery(
        int Id) : IRequest<ErrorOr<Admin>>;
}