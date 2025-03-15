using Inc.Hecate.Auth.Shared.Models.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.IoC.Authentication
{
    public static class AuthenticationInjection
    {
        public static IServiceCollection AddAuthenticationInc(this IServiceCollection services, ApplicationConfig configuration)
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.Authentication.Key)),
                        ClockSkew = TimeSpan.Zero
                    };

                    options.Events = new JwtBearerEvents()
                    {
                        OnChallenge = context =>
                        {
                            // Skip the default logic.
                            context.HandleResponse();

                            var payload = new JObject
                            {
                                ["title"] = "Sessão Expirada",
                                ["erroInformal"] = "Sessão expirada devido a inatividade ou tempo limite de acesso. Será necessário fazer o acesso novamente.",
                                ["erroFormal"] = "Token Invalido ou Usuario não Autenticado"
                            };

                            context.Response.ContentType = "application/json";
                            context.Response.StatusCode = 401;

                            return context.Response.WriteAsync(payload.ToString());
                        }
                    };

                });

            return services;
        }
    }
}
