using ErrorOr;
using MediatR;
using Oseredok.Domain.Entities;

namespace Oseredok.Application.Users.Commands.UpdateRole
{
    public record UserUpdateRoleCommand(
        Guid Id,
        string RoleName) : IRequest<ErrorOr<User>>;
}