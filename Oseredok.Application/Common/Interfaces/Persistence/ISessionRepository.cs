using ErrorOr;
using Oseredok.Domain.Entities;
using Oseredok.Shared.DTOs.Common;
using Oseredok.Shared.DTOs.Session;

namespace Oseredok.Application.Common.Interfaces.Persistence
{
    public interface ISessionRepository
    {
        Task<ErrorOr<IEnumerable<Session>>> GetAll();

        Task<IEnumerable<Session>?> GetAllByGym(int gymId);

        Task<ErrorOr<IEnumerable<Session>>> GetAllByCoach(Guid coachId);

        Task<ErrorOr<Session>> GetById(Guid id);

        Task<ErrorOr<Session>> Update(SessionUpdateDto sessionUpdateDto);

        Task<ErrorOr<Session>> UpdateSessionStatus(SessionStatusUpdateDto dto);

        Task<ErrorOr<IsDeletedDto>> Delete(Guid id);

        Task<ErrorOr<Session>> Add(SessionCreateDto sessionCreateDto);
    }
}