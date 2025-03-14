using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Shared.Models.Configuration
{
    public record FileConfiguration
    {
        public string UrlSaveFiles { get; init; }
        public string UrlPublish { get; init; }
    }
}
