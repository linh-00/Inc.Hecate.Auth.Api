using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Aplication.DTO.Reponse
{
    public record ConfimTokenRequest
    {
        public string password { get; init; }
        public string TokenConfirmacao { get; init; }
    }
}
