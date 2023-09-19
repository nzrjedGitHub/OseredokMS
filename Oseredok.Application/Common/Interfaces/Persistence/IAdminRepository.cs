using ErrorOr;
using Oseredok.Domain.Entities;
using Oseredok.Shared.DTOs.Admin;
using Oseredok.Shared.DTOs.Common;

namespace Oseredok.Application.Common.Interfaces.Persistence
{
    public interface IAdminRepository
    {
        Task<ErrorOr<IEnumerable<Admin>?>> GetAll();

        Task<IEnumerable<Admin>?> GetAllByGym(int gymId);

        Task<ErrorOr<Admin>> GetById(Guid id);

        Task<ErrorOr<Admin>> GetByUserId(Guid id);

        Task<ErrorOr<Admin>> Update(AdminUpdateDto adminUpdateDto);

        Task<IsDeletedDto> Delete(Admin admin);

        Task Add(AdminCreateDto adminCreateDto);
    }
}