using ErrorOr;
using MediatR;
using Oseredok.Domain.Entities;

namespace Oseredok.Application.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(
        Guid id) : IRequest<ErrorOr<User>>;
}