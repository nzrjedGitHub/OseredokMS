using Oseredok.Domain.Entities;

namespace Oseredok.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}