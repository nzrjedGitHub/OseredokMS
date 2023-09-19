using ErrorOr;
using Oseredok.Domain.Entities;

namespace Oseredok.Application.Common.Interfaces.Persistence
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>?> GetAll();

        Task<ErrorOr<Role>> GetById(int id);

        Task<ErrorOr<Role>> GetByName(string name);
    }
}