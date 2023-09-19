using ErrorOr;
using MapsterMapper;
using MediatR;
using Oseredok.Application.Authentication.Common;
using Oseredok.Application.Common.Interfaces.Authentication;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Domain.Common.Errors;
using Oseredok.Domain.Entities;

namespace Oseredok.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterCommandHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var UserWithSameEmail = await _userRepository.GetUserByEmail(command.Email);
            if (UserWithSameEmail?.Email == command.Email)
            {
                return Errors.User.DuplicateEmail;
            }
            var UserWithSamePhoneNumber = await _userRepository.GetUserByPhoneNumber(command.PhoneNumber);
            if (UserWithSamePhoneNumber?.PhoneNumber == command.PhoneNumber)
            {
                return Errors.User.DuplicatePhoneNumber;
            }

            var newUser = _mapper.Map<User>(command);

            await _userRepository.Add(newUser);

            var user = await _userRepository.GetById(newUser.Id);

            var token = _jwtTokenGenerator.GenerateToken(user.Value);

            return new AuthenticationResult(
                user.Value.Id,
                user.Value.Role.Name,
                user.Value.FirstName,
                user.Value.LastName,
                user.Value.Email,
                user.Value.Password,
                token);
        }
    }
}