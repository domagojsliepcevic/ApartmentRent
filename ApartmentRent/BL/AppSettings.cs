using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Configuration;
using System.IO;

namespace ApartmentRent.BL
{
    // singleton pattern

    public class AppSettings
    {
        private static readonly Lazy<AppSettings> _instance = new Lazy<AppSettings>(() => new AppSettings());

        public static AppSettings Instance { get { return _instance.Value; } }

        private IConfiguration _configuration;

        private AppSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();
        }

        public string ConnectionString { get { return _configuration.GetConnectionString("DatabaseContext"); } }
    }
}
