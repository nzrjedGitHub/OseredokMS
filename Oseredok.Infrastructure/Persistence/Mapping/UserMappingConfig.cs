using Mapster;
using Oseredok.Domain.Entities;
using Oseredok.Shared.DTOs.User;

namespace Oseredok.Infrastructure.Persistence.Mapping
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, UserShortDto>()
                .Map(dest => dest.RoleName, src => src.Role.Name);
        }
    }
}