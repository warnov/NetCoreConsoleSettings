using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NetCoreConsoleSettings
{
    public static class ConfigHelper
    {
        public static IConfiguration Config
        {
            get
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
                return builder.Build();
            }
        }
    }
}
