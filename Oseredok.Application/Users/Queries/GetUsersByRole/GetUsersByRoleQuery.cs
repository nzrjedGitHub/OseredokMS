using ErrorOr;
using MediatR;
using Oseredok.Domain.Entities;

namespace Oseredok.Application.Users.Queries.GetUsersByRole
{
    public record GetUsersByRoleQuery(string role) : IRequest<ErrorOr<IEnumerable<User>>>;
}