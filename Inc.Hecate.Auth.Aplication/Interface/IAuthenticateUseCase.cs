using Inc.Hecate.Auth.Aplication.DTO.Reponse;
using Inc.Hecate.Auth.Aplication.DTO.Request;
using Inc.Hecate.Auth.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Aplication.Interface
{
    public interface IAuthenticateUseCase : IUseCase<LoginRequest, BearerToken>
    {
    }
}
