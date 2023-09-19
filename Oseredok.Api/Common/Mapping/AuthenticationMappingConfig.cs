using Mapster;
using Oseredok.Application.Authentication.Commands.Register;
using Oseredok.Application.Authentication.Common;
using Oseredok.Application.Authentication.Queries.Login;
using Oseredok.Contracts.Authentication;
using Oseredok.Domain.Entities;

namespace Oseredok.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest.Role, src => src.role)
                .Map(dest => dest, src => src);

            config.NewConfig<RegisterRequest, RegisterCommand>()
                .Map(dest => dest, src => src);

            config.NewConfig<AuthenticationResult, User>()
                .Map(dest => dest, src => src);
        }
    }
}