using Inc.Hecate.Auth.Aplication.Interface.Services;
using Inc.Hecate.Auth.Aplication.UseCase.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.IoC.Services
{
    public static class ServicesInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IAuthTokenService, AuthTokenService>();
            return services;
        }
    }
}

