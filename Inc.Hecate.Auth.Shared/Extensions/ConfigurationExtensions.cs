using Inc.Hecate.Auth.Shared.Models.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Shared.Extensions
{
    public static class ConfigurationExtensions
    {
        public static ApplicationConfig LoadConfiguration(this IConfiguration Source)
        {
            var applicationConfig = Source.Get<ApplicationConfig>();
            return applicationConfig!;
        }
    }
}
