using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Aplication.DTO.Reponse
{
    public record BearerToken
    {
        public string AccessToken { get; init; }
        public DateTime Expiration { get; init; }
    }
}
