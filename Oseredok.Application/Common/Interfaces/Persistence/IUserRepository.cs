using ErrorOr;
using Oseredok.Domain.Entities;
using Oseredok.Shared.DTOs.Common;
using Oseredok.Shared.DTOs.User;

namespace Oseredok.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmail(string email);

        Task<User?> GetUserByPhoneNumber(string pNumber);

        Task Add(User user);

        Task<ErrorOr<IEnumerable<User>>> GetAllByRole(string role);

        Task<IEnumerable<User>?> GetAll();

        Task<ErrorOr<User>> GetById(Guid id);

        Task<ErrorOr<User>> Update(UserUpdateDto userUpdateDto);

        Task<ErrorOr<User>> UpdateRole(UserUpdateRoleDto userUpdateRoleDto);

        Task<IsDeletedDto> Delete(User user);
    }
}