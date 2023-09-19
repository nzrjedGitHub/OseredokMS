namespace Oseredok.Contracts.User
{
    public record UserUpdateRoleRequest(
        Guid Id,
        string RoleName);
}