using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Domain.Common.Errors;
using Oseredok.Domain.Entities;

namespace Oseredok.Infrastructure.Persistence.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _ctx;

        public RoleRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Role>?> GetAll()
        {
            return await _ctx.Roles
               .ToListAsync();
        }

        public async Task<ErrorOr<Role>> GetById(int id)
        {
            var role = await _ctx.Roles
                .FirstOrDefaultAsync(role => role.Id == id);
            if (role == null)
            {
                return Errors.Role.InvalidId;
            }
            return role;
        }

        public async Task<ErrorOr<Role>> GetByName(string name)
        {
            var role = await _ctx.Roles
                .FirstOrDefaultAsync(role => role.Name == name);
            if (role == null)
            {
                return Errors.Role.InvalidRole;
            }
            return role;
        }
    }
}