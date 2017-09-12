using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace L.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = new LoggerFactory();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSetting("detailedErrors", "true")
                .CaptureStartupErrors(true)
                .Build();
    }
}