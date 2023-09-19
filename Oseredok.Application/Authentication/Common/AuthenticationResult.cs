namespace Oseredok.Application.Authentication.Common
{
    public record AuthenticationResult(

    Guid Id,

    string role,

    string FirstName,

    string LastName,

    string Email,

    string Password,

    string? Token
    );
}