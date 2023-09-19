using ErrorOr;
using MediatR;
using Oseredok.Application.Authentication.Common;
using Oseredok.Application.Common.Interfaces.Authentication;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Domain.Common.Errors;

namespace Oseredok.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // 1. Validate the user exists
            var user = await _userRepository.GetUserByEmail(query.Email);
            if (user == null)
            {
                return Errors.Authentication.InvalidCredentials;
            }
            // 2. Validate the password is correct
            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }
            // 3. Create Jwt token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user.Id,
                user.Role.Name,
                user.FirstName,
                user.LastName,
                user.Email,
                user.Password,
                token);
        }
    }
}