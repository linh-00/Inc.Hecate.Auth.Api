using Inc.Hecate.Auth.Aplication.DTO.Reponse;
using Inc.Hecate.Auth.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Aplication.Interface.Services
{
    public interface IAuthTokenService 
    {
        Task<BearerToken> BuildToken(User userInfo);
    }
}
