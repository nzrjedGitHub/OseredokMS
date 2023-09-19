using ErrorOr;
using Oseredok.Domain.Entities;
using Oseredok.Shared.DTOs.Common;
using Oseredok.Shared.DTOs.Gym;

namespace Oseredok.Application.Common.Interfaces.Persistence
{
    public interface IGymRepository
    {
        Task<IEnumerable<Gym>?> GetAll();

        Task<ErrorOr<Gym>> GetById(int id);

        Task<ErrorOr<Gym>> Update(GymUpdateDto gymUpdateDto);

        Task<IsDeletedDto> Delete(Gym gym);

        Task Add(GymCreateDto gymCreateDto);
    }
}