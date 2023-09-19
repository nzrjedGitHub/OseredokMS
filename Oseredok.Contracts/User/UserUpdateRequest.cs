namespace Oseredok.Contracts.User
{
    public record UserUpdateRequest(
        Guid Id,

        string FirstName,

        string LastName,

        string MiddleName,

        string PhoneNumber,

        string Email);
}