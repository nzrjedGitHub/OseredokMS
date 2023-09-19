using ErrorOr;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Domain.Common.Errors;
using Oseredok.Domain.Entities;
using Oseredok.Shared.DTOs.Common;
using Oseredok.Shared.DTOs.Gym;

namespace Oseredok.Infrastructure.Persistence.Repositories
{
    public class GymRepository : IGymRepository
    {
        private readonly AppDbContext _ctx;

        public GymRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Add(GymCreateDto gymCreateDto)
        {
            var newGym = new Gym();
            newGym = gymCreateDto.Adapt(newGym);
            await _ctx.AddAsync(newGym);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IsDeletedDto> Delete(Gym gym)
        {
            _ctx.Gyms.Remove(gym);
            await _ctx.SaveChangesAsync();
            var result = new IsDeletedDto()
            {
                IsDeleted = true
            };
            return result;
        }

        public async Task<IEnumerable<Gym>?> GetAll()
        {
            return await _ctx.Gyms
                .ToListAsync();
        }

        public async Task<ErrorOr<Gym>> GetById(int id)
        {
            var gym = await _ctx.Gyms
                .FirstOrDefaultAsync(gym => gym.Id == id);
            if (gym == null)
            {
                return Errors.Gym.InvalidId;
            }
            return gym;
        }

        public async Task<ErrorOr<Gym>> Update(GymUpdateDto gymUpdateDto)
        {
            var gym = await _ctx.Gyms
                .FirstOrDefaultAsync(gym => gym.Id == gymUpdateDto.Id);
            if (gym == null)
            {
                return Errors.Admin.InvalidId;
            }
            gym = gymUpdateDto.Adapt(gym);
            await _ctx.SaveChangesAsync();
            return gym;
        }
    }
}