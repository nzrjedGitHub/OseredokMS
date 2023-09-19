using ErrorOr;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Domain.Common.Errors;
using Oseredok.Domain.Entities;
using Oseredok.Shared.DTOs.Common;
using Oseredok.Shared.DTOs.User;

namespace Oseredok.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _ctx;
        private readonly IMapper _mapper;

        public UserRepository(AppDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task Add(User user)
        {
            user.Id = Guid.NewGuid();
            user.RoleId = 4;
            user.RegDate = DateTime.Now;
            await _ctx.AddAsync(user);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>?> GetAll()
        {
            return await _ctx.Users
                .Include(user => user.Role)
                .ToListAsync();
        }

        public async Task<ErrorOr<IEnumerable<User>>> GetAllByRole(string role)
        {
            var isRoleExist = _ctx.Roles.Any(r => r.Name == role);
            if (!isRoleExist)
            {
                return Errors.Role.InvalidRole;
            }
            var userList = await _ctx.Users
                .Include(user => user.Role)
                .Where(user => user.Role.Name == role)
                .ToListAsync();
            return userList;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _ctx.Users
                .Include(user => user.Role)
                .FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<User?> GetUserByPhoneNumber(string pNumber)
        {
            return await _ctx.Users
                .Include(user => user.Role)
                .FirstOrDefaultAsync(user => user.PhoneNumber == pNumber);
        }

        public async Task<ErrorOr<User>> GetById(Guid id)
        {
            var user = await _ctx.Users
                .Include(user => user.Role)
                .FirstOrDefaultAsync(user => user.Id == id);
            if (user == null)
            {
                return Errors.User.InvalidId;
            }
            return user;
        }

        public async Task<ErrorOr<User>> Update(UserUpdateDto userUpdateDto)
        {
            var user = await _ctx.Users
                .Include(user => user.Role)
                .FirstOrDefaultAsync(user => user.Id == userUpdateDto.Id);
            if (user == null)
            {
                return Errors.User.InvalidId;
            }
            if (user.Email != userUpdateDto.Email)
            {
                var isEmailDuplicated = await _ctx.Users
                .AnyAsync(user => user.Email == userUpdateDto.Email);

                if (isEmailDuplicated)
                {
                    return Errors.User.DuplicateEmail;
                }
            }
            user = userUpdateDto.Adapt(user);
            await _ctx.SaveChangesAsync();
            return user;
        }

        public async Task<IsDeletedDto> Delete(User user)
        {
            _ctx.Users.Remove(user);
            await _ctx.SaveChangesAsync();
            var result = new IsDeletedDto()
            {
                IsDeleted = true,
            };
            return result;
        }

        public async Task<ErrorOr<User>> UpdateRole(UserUpdateRoleDto userUpdateRoleDto)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(user => user.Id == userUpdateRoleDto.Id);
            if (user == null)
            {
                return Errors.User.InvalidId;
            }
            var role = await _ctx.Roles.FirstOrDefaultAsync(role => role.Name == userUpdateRoleDto.RoleName);
            if (role == null)
            {
                return Errors.User.InvalidRoleName;
            }
            user.Role = role;
            if (role.Name == "admin")
            {
                var newAdmin = new Admin
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    Salary = 0,
                    GymId = 1
                };
                await _ctx.AddAsync(newAdmin);
            }
            else if (role.Name == "client")
            {
                var newClientPayment = new ClientPayment
                {
                    Id = Guid.NewGuid(),
                    PaymentPerSession = 0,
                    Balance = 0,
                };
                var defaultCoachId = Guid.Parse("d4e61167-950b-4d87-b568-9ce087f3c744"); //default coach
                var newClient = new Client
                {
                    Id = Guid.NewGuid(),
                    //CoachId = _ctx.Coaches.FirstOrDefault(x => x.Id == defaultCoachId).Id,
                    CoachId = defaultCoachId,
                    //GymId = _ctx.Gyms.FirstOrDefault(x => x.Id == 1).Id,
                    GymId = 1,
                    //UserId = _ctx.Users.FirstOrDefault(x => x.Id == user.Id).Id,
                    UserId = user.Id,
                    ClientPaymentId = newClientPayment.Id,
                };
                await _ctx.AddAsync(newClientPayment);
                await _ctx.AddAsync(newClient);
            }
            else if (role.Name == "coach")
            {
                var newCoach = new Coach
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    PercentagePerSession = 0,
                };
                await _ctx.AddAsync(newCoach);
            }

            await _ctx.SaveChangesAsync();

            return user;
        }
    }
}