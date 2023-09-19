using ErrorOr;
using MediatR;
using Oseredok.Domain.Entities;

namespace Oseredok.Application.Users.Commands.Update
{
    public record UserUpdateCommand(

        Guid Id,

        string FirstName,

        string LastName,

        string MiddleName,

        string PhoneNumber,

        string Email,

        DateTime DateOfBirth,

        string ProfileImgPath) : IRequest<ErrorOr<User>>;
}