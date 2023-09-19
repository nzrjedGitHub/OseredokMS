using ErrorOr;
using MediatR;
using Oseredok.Shared.DTOs.Common;

namespace Oseredok.Application.Users.Commands.Delete
{
    public record UserDeleteCommand(
        Guid Id) : IRequest<ErrorOr<IsDeletedDto>>;
}