using ErrorOr;
using MediatR;
using Oseredok.Application.Authentication.Common;
using Oseredok.Shared.DTOs.Login;

namespace Oseredok.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}