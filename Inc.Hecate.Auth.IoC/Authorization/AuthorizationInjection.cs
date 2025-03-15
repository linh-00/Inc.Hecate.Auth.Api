using Inc.Hecate.Auth.Shared.Models.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.IoC.Authorization
{
    public static class AuthorizationInjection
    {
        public static IServiceCollection AddAuthorizationInc(this IServiceCollection services, ApplicationConfig configuration)
        {
            services.Configure<AuthorizationOptions>(options =>
            {
                //options.AddPolicy(policy => policy.RequireClaim(ClaimTypes.Surname, configuration.Authorization.Organization));
            });

            return services;
        }
    }
}
