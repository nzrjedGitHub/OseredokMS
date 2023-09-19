using ErrorOr;
using MediatR;
using Oseredok.Application.Authentication.Common;

namespace Oseredok.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
     string FirstName,

     string LastName,

     string MiddleName,

     string PhoneNumber,

     string Email,

     string Password,

     DateTime DateOfBirth) : IRequest<ErrorOr<AuthenticationResult>>;
}