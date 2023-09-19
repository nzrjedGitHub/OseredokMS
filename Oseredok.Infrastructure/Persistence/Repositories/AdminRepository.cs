using ErrorOr;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Domain.Common.Errors;
using Oseredok.Domain.Entities;
using Oseredok.Shared.DTOs.Admin;
using Oseredok.Shared.DTOs.Common;

namespace Oseredok.Infrastructure.Persistence.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _ctx;
        private readonly IMapper _mapper;

        public AdminRepository(IMapper mapper, AppDbContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public async Task Add(AdminCreateDto adminCreateDto)
        {
            var newAdmin = new Admin
            {
                Id = Guid.NewGuid(),
            };
            newAdmin = adminCreateDto.Adapt(newAdmin);
            await _ctx.AddAsync(newAdmin);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IsDeletedDto> Delete(Admin admin)
        {
            _ctx.Admins.Remove(admin);
            await _ctx.SaveChangesAsync();
            var result = new IsDeletedDto()
            {
                IsDeleted = true
            };
            return result;
        }

        public async Task<ErrorOr<IEnumerable<Admin>?>> GetAll()
        {
            return await _ctx.Admins
                .Include(admin => admin.User).ThenInclude(user => user.Role)
                .ToListAsync();
        }

        public async Task<IEnumerable<Admin>?> GetAllByGym(int gymId)
        {
            return await _ctx.Admins
                .Include(admin => admin.User).ThenInclude(user => user.Role)
                .Where(admin => admin.Gym.Id == gymId)
                .ToListAsync();
        }

        public async Task<ErrorOr<Admin>> GetById(Guid id)
        {
            var admin = await _ctx.Admins
                .Include(admin => admin.User).ThenInclude(user => user.Role)
                .FirstOrDefaultAsync(admin => admin.Id == id);
            if (admin == null)
            {
                return Errors.Admin.InvalidId;
            }
            return admin;
        }

        public async Task<ErrorOr<Admin>> GetByUserId(Guid id)
        {
            var admin = await _ctx.Admins
                .Include(admin => admin.User).ThenInclude(user => user.Role)
                .FirstOrDefaultAsync(admin => admin.User.Id == id);
            if (admin == null)
            {
                return Errors.User.InvalidId;
            }
            return admin;
        }

        public async Task<ErrorOr<Admin>> Update(AdminUpdateDto adminUpdateDto)
        {
            var admin = await _ctx.Admins
                .Include(admin => admin.User).ThenInclude(user => user.Role)
                .FirstOrDefaultAsync(admin => admin.Id == adminUpdateDto.Id);
            if (admin == null)
            {
                return Errors.Admin.InvalidId;
            }
            admin = adminUpdateDto.Adapt(admin);
            await _ctx.SaveChangesAsync();
            return admin;
        }
    }
}