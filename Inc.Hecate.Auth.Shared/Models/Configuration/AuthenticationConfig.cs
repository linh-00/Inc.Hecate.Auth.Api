using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Shared.Models.Configuration
{
    public record AuthenticationConfig
    {
        public string Key { get; init; }
    }
}
