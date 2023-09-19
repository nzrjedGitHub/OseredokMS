using ErrorOr;
using Oseredok.Domain.Entities;
using Oseredok.Shared.DTOs.Client;
using Oseredok.Shared.DTOs.Common;

namespace Oseredok.Application.Common.Interfaces.Persistence
{
    public interface IClientRepository
    {
        Task<ErrorOr<IEnumerable<Client>>> GetAll();

        Task<IEnumerable<Client>?> GetAllByGym(int gymId);

        Task<ErrorOr<Client>> GetById(Guid id);

        Task<ErrorOr<Client>> Update(ClientUpdateDto clientUpdateDto);

        Task<IsDeletedDto> Delete(Client client);

        Task Add(ClientCreateDto clientCreateDto);
    }
}