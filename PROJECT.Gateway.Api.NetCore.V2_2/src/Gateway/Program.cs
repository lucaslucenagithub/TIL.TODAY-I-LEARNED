using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gateway.Aggregators;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder()
             .UseKestrel(options =>
                {
                    options.ListenLocalhost(3000);
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                        .AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                        .AddJsonFile("ocelot.json")
                        .AddEnvironmentVariables();
                })
                .ConfigureServices(s =>
                {
                    var authenticationProviderKey = "TestKey";
                    var tokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = "GatewayTeste",
                        ValidAudience = "https://localhost:3000/",
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("fW7DaKxk8XXx97DBbpyaM3QrVnumnm84JTGL6RmcKsuDVvLH2fmVv7YMnQzCVGhcUjTJGwkUyfTjVccJYV2AcqsRZLRDfCx42ssEAPeN8bpt84Shb3KdtMrEKYwwHvfMQa4Szggd4p2MzTLPfZ4mbVggU9PXQdXwxmV3aewRA8a7AKMkyTHJ9Fx2phfFL4kgce22tbgCQFqMEPL7WzgKrwK9GSQrEhEs76JFgB4tS5p98CLYRk6E5XRxfzqeqCbgzPsKJCkvycDhapdvBTksPvBDR5f8YwpYU9QTR6vCpF2K63PEQgRXa9LxkQL8RNBbvfc37Xt4XdxujJWaDMtNWeADeQ2vvyc23V3e8x8dM8G8KyT7wdAESr9Jwm3dFFUL8xuMdrQU95MbWNEZpfhvzMRdXd77Uey7gr6tx2Kcj2jpnxM3RxQVvztbCbvZYxbWK5yah9E5EMfK87NnjZ8dHsNyCVuy4Z9zJVMMGdYPuRHVrJcybxVr8pK7MBaN3Lf5")),
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        RequireSignedTokens = true,
                    };

                    s.AddAuthentication(options =>
                   {
                       options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                       options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                   })
                   .AddJwtBearer(authenticationProviderKey, x =>
                    {
                        x.RequireHttpsMetadata = false;
                        x.TokenValidationParameters = tokenValidationParameters;
                    });

                    s.AddOcelot()
                    .AddTransientDefinedAggregator<QuizUsuarioAggregator>();
                    //mais aggregators
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    //add your logging
                })
                .UseIISIntegration()
                .Configure(app =>
                {
                    app.UseAuthentication();
                    app.UseOcelot().Wait();
                })
                .Build()
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
