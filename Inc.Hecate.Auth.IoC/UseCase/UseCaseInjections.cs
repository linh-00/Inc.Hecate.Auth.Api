using Inc.Hecate.Auth.Aplication.Interface;
using Inc.Hecate.Auth.Aplication.UseCase.Authenticator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.IoC.UseCase
{
    public static class UseCaseInjections
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthenticateUseCase, AuthenticateUseCase>();       

            return services;
        }
    }
}
