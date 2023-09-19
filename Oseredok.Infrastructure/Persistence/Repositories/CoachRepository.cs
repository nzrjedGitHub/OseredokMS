using ErrorOr;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Domain.Common.Errors;
using Oseredok.Domain.Entities;
using Oseredok.Shared.DTOs.Coach;
using Oseredok.Shared.DTOs.Common;

namespace Oseredok.Infrastructure.Persistence.Repositories
{
    public class CoachRepository : ICoachRepository
    {
        private readonly AppDbContext _ctx;

        public CoachRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Add(CoachCreateDto coachCreateDto)
        {
            var newCoach = new Coach()
            {
                Id = Guid.NewGuid()
            };
            newCoach = coachCreateDto.Adapt(newCoach);
            await _ctx.AddAsync(newCoach);
            await _ctx.SaveChangesAsync();
        }

        public async Task<ErrorOr<Coach>> AddClientToCoach(ClientCoachDto clientCoachDto)
        {
            var coach = await _ctx.Coaches
                .Include(coach => coach.User).ThenInclude(user => user.Role)
                .FirstOrDefaultAsync(coach => coach.Id == clientCoachDto.CoachId);
            if (coach == null)
            {
                return Errors.Coach.InvalidId;
            }
            var client = await _ctx.Clients
                .FirstOrDefaultAsync(client => client.Id == clientCoachDto.ClientId);
            if (client == null)
            {
                return Errors.Client.InvalidId;
            }
            coach.Clients.Add(client);
            return coach;
        }

        public async Task<IsDeletedDto> Delete(Coach coach)
        {
            _ctx.Coaches.Remove(coach);
            await _ctx.SaveChangesAsync();
            var result = new IsDeletedDto()
            {
                IsDeleted = true
            };
            return result;
        }

        public async Task<ErrorOr<Coach>> DeleteClientFromCoach(ClientCoachDto clientCoachDto)
        {
            var coach = await _ctx.Coaches
                .Include(coach => coach.User).ThenInclude(user => user.Role)
                .FirstOrDefaultAsync(coach => coach.Id == clientCoachDto.CoachId);
            if (coach == null)
            {
                return Errors.Coach.InvalidId;
            }
            var client = await _ctx.Clients
                .FirstOrDefaultAsync(client => client.Id == clientCoachDto.ClientId);
            if (client == null)
            {
                return Errors.Client.InvalidId;
            }
            coach.Clients.Remove(client);
            return coach;
        }

        public async Task<ErrorOr<IEnumerable<Coach>>> GetAll()
        {
            return await _ctx.Coaches
                .Include(coach => coach.User).ThenInclude(user => user.Role)
                .ToListAsync();
        }

        public async Task<IEnumerable<Coach>?> GetAllByGym(int gymId)
        {
            return await _ctx.Coaches
                .Include(coach => coach.User).ThenInclude(user => user.Role)
                .Where(coach => coach.GymId == gymId)
                .ToListAsync();
        }

        public async Task<ErrorOr<Coach>> GetById(Guid id)
        {
            var coach = await _ctx.Coaches
                .Include(coach => coach.User).ThenInclude(user => user.Role)
                .Include(coach => coach.Clients)
                .Include(coach => coach.Sessions)

                .FirstOrDefaultAsync(coach => coach.Id == id);
            if (coach == null)
            {
                return Errors.Coach.InvalidId;
            }
            return coach;
        }

        public async Task<ErrorOr<CoachSalaryDto>> GetCoachSalary(GetCoachSalaryDto salaryDto)
        {
            var coach = await _ctx.Coaches
                .Include(coach => coach.User).ThenInclude(user => user.Role)
                .Include(coach => coach.Sessions).ThenInclude(sessions => sessions.SessionStatus)
                .Include(coach => coach.Sessions).ThenInclude(sessions => sessions.Client).ThenInclude(c => c.ClientPayment)
                .Include(coach => coach.Clients).ThenInclude(client => client.ClientPayment)
                .FirstOrDefaultAsync(coach => coach.Id == salaryDto.Id);

            if (coach == null)
            {
                return Errors.Coach.InvalidId;
            }
            var salary = new CoachSalaryDto();
            bool isDateInRange(DateTime date)
            {
                if (date >= salaryDto.FromDate && date <= salaryDto.TillDate) return true;
                else return false;
            }
            decimal totalCP = 0;

            foreach (var sesion in coach.Sessions)
            {
                if (sesion.SessionStatus.Name == "completed" && isDateInRange(sesion.SessionDate))
                {
                    totalCP += sesion.Client.ClientPayment.PaymentPerSession;
                }
            }
            salary.Salary = coach.PercentagePerSession * totalCP;
            return salary;
        }

        public async Task<ErrorOr<Coach>> Update(CoachUpdateDto coachUpdateDto)
        {
            var coach = await _ctx.Coaches
                .Include(coach => coach.User).ThenInclude(user => user.Role)
                .FirstOrDefaultAsync(coach => coach.Id == coachUpdateDto.Id);
            if (coach == null)
            {
                return Errors.Admin.InvalidId;
            }
            coach = coachUpdateDto.Adapt(coach);
            await _ctx.SaveChangesAsync();
            return coach;
        }
    }
}