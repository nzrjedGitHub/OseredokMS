using ErrorOr;
using Oseredok.Domain.Entities;

namespace Oseredok.Application.Common.Interfaces.Persistence
{
    public interface ISessionStatusRepository
    {
        Task<IEnumerable<SessionStatus>?> GetAll();

        Task<ErrorOr<SessionStatus>> GetById(int id);

        Task<ErrorOr<SessionStatus>> GetByName(string name);
    }
}