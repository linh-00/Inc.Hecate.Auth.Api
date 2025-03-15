using Inc.Hecate.Auth.Shared.Utils.Interfaces;
using Inc.Hecate.Auth.Shared.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inc.Hecate.Auth.Shared.Extensions;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Inc.Hecate.Auth.IoC.Repositories;
using Inc.Hecate.Auth.IoC.Services;
using Inc.Hecate.Auth.IoC.UseCase;
using Inc.Hecate.Auth.IoC.Authentication;
using Inc.Hecate.Auth.IoC.Authorization;
using Inc.Hecate.Auth.IoC.Mappings;

namespace Inc.Hecate.Auth.IoC
{
    public static class DependenceInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var appConfig = configuration.LoadConfiguration();
            services.AddSingleton(appConfig);
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IEncryptor, Encryptor>();

            services.AddRepositories(configuration);
            services.AddServices(configuration);
            services.AddUseCases(configuration);

            services.AddAuthenticationInc(appConfig);
            services.AddAuthorizationInc(appConfig);

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
