using ErrorOr;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Domain.Common.Errors;
using Oseredok.Domain.Entities;
using Oseredok.Shared.DTOs.Common;
using Oseredok.Shared.DTOs.Session;

namespace Oseredok.Infrastructure.Persistence.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly AppDbContext _ctx;

        public SessionRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<ErrorOr<Session>> Add(SessionCreateDto sessionCreateDto)
        {
            var newSession = new Session
            {
                Id = Guid.NewGuid(),
            };
            newSession = sessionCreateDto.Adapt(newSession);
            await _ctx.AddAsync(newSession);
            await _ctx.SaveChangesAsync();

            return newSession;
        }

        public async Task<ErrorOr<IsDeletedDto>> Delete(Guid id)
        {
            var session = _ctx.Sessions.FirstOrDefault(s => s.Id == id);
            _ctx.Sessions.Remove(session);
            await _ctx.SaveChangesAsync();
            var result = new IsDeletedDto()
            {
                IsDeleted = true
            };
            return result;
        }

        public async Task<ErrorOr<IEnumerable<Session>>> GetAll()
        {
            return await _ctx.Sessions
                .Include(s => s.Client).ThenInclude(c => c.User)
                .Include(s => s.Coach).ThenInclude(c => c.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Session>?> GetAllByGym(int gymId)
        {
            return await _ctx.Sessions
                .Where(session => session.GymId == gymId)
                .ToListAsync();
        }

        public async Task<ErrorOr<IEnumerable<Session>>> GetAllByCoach(Guid coachId)
        {
            var sessions = await _ctx.Sessions
                .Where(session => session.Coach.Id == coachId)
                .Include(s => s.Client).ThenInclude(c => c.User)
                .Include(s => s.Coach).ThenInclude(c => c.User)
                .ToListAsync();
            if (sessions == null)
            {
                return Errors.Session.InvalidId;
            }
            return sessions;
        }

        public async Task<ErrorOr<Session>> GetById(Guid id)
        {
            var session = await _ctx.Sessions
                .Include(s => s.Client).ThenInclude(c => c.User)
                .Include(s => s.Coach).ThenInclude(c => c.User)
                .FirstOrDefaultAsync(session => session.Id == id);
            if (session == null)
            {
                return Errors.Session.InvalidId;
            }
            return session;
        }

        public async Task<ErrorOr<Session>> UpdateSessionStatus(SessionStatusUpdateDto dto)
        {
            var session = await _ctx.Sessions
                .Include(s => s.Client).ThenInclude(c => c.User)
                .Include(s => s.Coach).ThenInclude(c => c.User)
                .FirstOrDefaultAsync(session => session.Id == dto.Id);
            if (session == null)
            {
                return Errors.Session.InvalidId;
            }
            session = dto.Adapt(session);
            await _ctx.SaveChangesAsync();
            return session;
        }

        public async Task<ErrorOr<Session>> Update(SessionUpdateDto sessionUpdateDto)
        {
            var session = await _ctx.Sessions
                .FirstOrDefaultAsync(session => session.Id == sessionUpdateDto.Id);
            if (session == null)
            {
                return Errors.Session.InvalidId;
            }
            session = sessionUpdateDto.Adapt(session);
            await _ctx.SaveChangesAsync();
            return session;
        }
    }
}