using Oseredok.Shared.DTOs.Login;

namespace Oseredok.Contracts.Authentication
{
    public record LoginRequest(
        string Email,
        string Password
    );
}