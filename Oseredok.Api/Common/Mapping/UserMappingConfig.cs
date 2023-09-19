using Mapster;
using Oseredok.Application.Users.Commands.UpdateRole;
using Oseredok.Contracts.User;

namespace Oseredok.Api.Common.Mapping
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserUpdateRoleRequest, UserUpdateRoleCommand>()
                .Map(dest => dest, src => src);
        }
    }
}