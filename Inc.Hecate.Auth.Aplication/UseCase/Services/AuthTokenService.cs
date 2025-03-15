using Inc.Hecate.Auth.Aplication.DTO.Reponse;
using Inc.Hecate.Auth.Aplication.Interface.Services;
using Inc.Hecate.Auth.Domain.Entity;
using Inc.Hecate.Auth.Shared.Extensions;
using Inc.Hecate.Auth.Shared.Models.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Aplication.UseCase.Services
{
    public class AuthTokenService : IAuthTokenService
    {
        private static ApplicationConfig _Configuration { get; set; }

        public AuthTokenService(IConfiguration configuration)
        {
            _Configuration = configuration.LoadConfiguration();
        }
        public async Task<BearerToken> BuildToken(User userInfo)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration.Authentication.Key));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // TEMPO DE EXPIRAÇÃO DO TOKEN: 1 HORA
            var expiration = DateTime.UtcNow.AddDays(7);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new BearerToken()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }        
    }
}
