using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Shared.Models.Configuration
{
    public record ApplicationConfig
    {
        public AuthenticationConfig Authentication { get; init; }
        public string BuildId { get; set; }
    }
}
