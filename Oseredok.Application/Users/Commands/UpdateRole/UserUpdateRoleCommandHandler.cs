using ErrorOr;
using MapsterMapper;
using MediatR;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Domain.Entities;
using Oseredok.Shared.DTOs.User;

namespace Oseredok.Application.Users.Commands.UpdateRole
{
    public class UserUpdateRoleCommandHandler : IRequestHandler<UserUpdateRoleCommand, ErrorOr<User>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserUpdateRoleCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<User>> Handle(UserUpdateRoleCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var user = await _userRepository.UpdateRole(_mapper.Map<UserUpdateRoleDto>(command));

            return user;
        }
    }
}