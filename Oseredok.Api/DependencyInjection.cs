using Microsoft.AspNetCore.Mvc.Infrastructure;
using Oseredok.Api.Common.Errors;
using Oseredok.Api.Common.Mapping;

namespace Oseredok.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, OseredokProblemDetailsFactory>();

            services.AddMappings();
            return services;
        }
    }
}