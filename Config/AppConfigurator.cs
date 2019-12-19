using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace TM.Core
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(@"/Users/p.petrov/source/repos/TaskManager/TaskManager/TM.Core/Services")
                .AddJsonFile("AppConfiguration.json");
            AppConfiguration = builder.Build();

        }
        public IConfiguration AppConfiguration { get; set; }
        public string Configure()
        {
            var version = AppConfiguration["version"];
            return version;
        }
    }
}
