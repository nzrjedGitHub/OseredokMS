using ErrorOr;
using MapsterMapper;
using MediatR;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Domain.Entities;
using Oseredok.Shared.DTOs.User;

namespace Oseredok.Application.Users.Commands.Update
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, ErrorOr<User>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserUpdateCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<User>> Handle(UserUpdateCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var user = await _userRepository.Update(_mapper.Map<UserUpdateDto>(command));

            return user;
        }
    }
}