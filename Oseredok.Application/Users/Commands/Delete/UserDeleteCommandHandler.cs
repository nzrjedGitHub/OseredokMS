using ErrorOr;
using MapsterMapper;
using MediatR;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Domain.Common.Errors;
using Oseredok.Shared.DTOs.Common;

namespace Oseredok.Application.Users.Commands.Delete
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand, ErrorOr<IsDeletedDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserDeleteCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<IsDeletedDto>> Handle(UserDeleteCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var user = await _userRepository.GetById(command.Id);
            if (user.Value == null)
            {
                return Errors.User.InvalidId;
            }
            var isDeleted = await _userRepository.Delete(user.Value);
            return isDeleted;
        }
    }
}