using Microsoft.Extensions.Configuration;
using System;

namespace L.Web
{
    public class AppSettings
    {
        private static readonly Lazy<AppSettings> _instance = new Lazy<AppSettings>(() => new AppSettings());

        public static AppSettings Instance => _instance.Value;

        public IConfigurationRoot Configuration { get; }

        private AppSettings()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        /// <summary>
        /// pathogen服务地址
        /// </summary>
        public string ServiceAddress => Configuration["hangfire.server.pathogenServiceAddress"];

       
    }
}