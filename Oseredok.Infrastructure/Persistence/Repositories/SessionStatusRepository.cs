using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Domain.Common.Errors;
using Oseredok.Domain.Entities;

namespace Oseredok.Infrastructure.Persistence.Repositories
{
    public class SessionStatusRepository : ISessionStatusRepository
    {
        private readonly AppDbContext _ctx;

        public SessionStatusRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<SessionStatus>?> GetAll()
        {
            return await _ctx.SessionStatuses
               .ToListAsync();
        }

        public async Task<ErrorOr<SessionStatus>> GetById(int id)
        {
            var role = await _ctx.SessionStatuses
                .FirstOrDefaultAsync(sStat => sStat.Id == id);
            if (role == null)
            {
                return Errors.SessionStatus.InvalidId;
            }
            return role;
        }

        public async Task<ErrorOr<SessionStatus>> GetByName(string name)
        {
            var role = await _ctx.SessionStatuses
                .FirstOrDefaultAsync(sStat => sStat.Name == name);
            if (role == null)
            {
                return Errors.SessionStatus.InvalidSessionStatus;
            }
            return role;
        }
    }
}