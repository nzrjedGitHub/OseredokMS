using ErrorOr;
using MediatR;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Domain.Entities;

namespace Oseredok.Application.Users.Queries.GetUsersByRole
{
    public class GetUsersByRoleQueryHandler : IRequestHandler<GetUsersByRoleQuery, ErrorOr<IEnumerable<User>>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersByRoleQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<IEnumerable<User>>> Handle(GetUsersByRoleQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var userList = _userRepository.GetAllByRole(query.role);

            return userList.Result;
        }
    }
}