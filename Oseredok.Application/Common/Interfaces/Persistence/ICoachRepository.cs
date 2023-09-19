using ErrorOr;
using Oseredok.Domain.Entities;
using Oseredok.Shared.DTOs.Coach;
using Oseredok.Shared.DTOs.Common;

namespace Oseredok.Application.Common.Interfaces.Persistence
{
    public interface ICoachRepository
    {
        Task<ErrorOr<IEnumerable<Coach>>> GetAll();

        Task<IEnumerable<Coach>?> GetAllByGym(int gymId);

        Task<ErrorOr<Coach>> GetById(Guid id);

        Task<ErrorOr<Coach>> Update(CoachUpdateDto coachUpdateDto);

        Task<ErrorOr<Coach>> AddClientToCoach(ClientCoachDto clientCoachDto);

        Task<ErrorOr<Coach>> DeleteClientFromCoach(ClientCoachDto clientCoachDto);

        Task<ErrorOr<CoachSalaryDto>> GetCoachSalary(GetCoachSalaryDto getCoachSalaryDto);

        Task<IsDeletedDto> Delete(Coach coach);

        Task Add(CoachCreateDto coachCreateDto);
    }
}