using Daenet.Common.Logging.Sql;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Dach.ElectionSystem.WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureLogging((ctx, builder) =>
                    {
                        builder.AddFile($"{Directory.GetCurrentDirectory()}\\Logs\\Log.txt", outputTemplate: "[{Timestamp:HH:mm:ss}][{Level:u3}][{SourceContext}]:{Message:lj}{NewLine}{Exception}");
                    });
                });
    }
}
