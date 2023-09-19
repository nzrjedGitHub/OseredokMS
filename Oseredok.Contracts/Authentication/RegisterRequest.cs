namespace Oseredok.Contracts.Authentication
{
    public record RegisterRequest(

     string FirstName,

     string LastName,

     string MiddleName,

     string PhoneNumber,

     string Email,

     string Password
    );
}