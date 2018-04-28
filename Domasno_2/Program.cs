using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace Domasno_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel(options =>
            {
                options.Limits.MaxConcurrentConnections = 20;
                options.Limits.MaxConcurrentUpgradedConnections = 20;
            })
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    //
                    // Serilog
                    //
                    var env = hostingContext.HostingEnvironment;
                    if (env.IsDevelopment())
                    {
                        Log.Logger = new LoggerConfiguration()
                               .MinimumLevel.Debug()
                               .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                               .Enrich.FromLogContext()
                               .WriteTo.RollingFile(Path.Combine(env.ContentRootPath, "logs/MyApp-{Date}.txt"))
                               .CreateLogger();
                    }
                    else
                    {
                        Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Warning()
                            .Enrich.FromLogContext()
                            .WriteTo.RollingFile(Path.Combine(env.ContentRootPath, "logs/MyApp-{Date}.txt"))
                            .CreateLogger();
                    }
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Serilog"));
                    logging.AddSerilog(dispose: true);
                })



                .UseStartup<Startup>()
                .Build();


    }
}
