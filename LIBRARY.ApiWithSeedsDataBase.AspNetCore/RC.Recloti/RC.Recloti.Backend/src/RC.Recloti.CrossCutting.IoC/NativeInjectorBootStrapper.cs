using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using RC.Recloti.Data.Context;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using NLog;
using RC.Recloti.CrossCutting.IoC.ScopeInjectors;
using AutoMapper;
using RC.Recloti.Business.Mapping;
using RC.Recloti.CrossCutting.IoC.Middleware;
using RC.Recloti.Domain.Enums;
using RC.Recloti.Data.Extensions;

namespace RC.Recloti.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ReclotiContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddAutoMapper(typeof(MappinProfiles));

            RepositoryScopeInjector.Add(services);
            ServiceScopeInjector.Add(services);

            services.AddSingleton<ILogger>(LogManager.GetCurrentClassLogger());

            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder.AllowAnyOrigin()
                                  .AllowAnyHeader()
                                  .AllowAnyMethod());
            });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JwtIssuer"],
                        ValidAudience = Configuration["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                    cfg.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            // Add the access_token as a claim, as we may actually need it
                            var accessToken = context.SecurityToken as JwtSecurityToken;
                            if (accessToken != null)
                            {
                                ClaimsIdentity identity = context.Principal.Identity as ClaimsIdentity;
                                if (identity != null)
                                {
                                    identity.AddClaim(new Claim(ClaimTypes.Role, accessToken.Claims.Where(c => c.Type == ClaimTypes.Role).First().Value));
                                    identity.AddClaim(new Claim("id", accessToken.Claims.Where(c => c.Type == "id").First().Value));
                                    identity.AddClaim(new Claim("name", accessToken.Claims.Where(c => c.Type == "name").First().Value));
                                    identity.AddClaim(new Claim("email", accessToken.Claims.Where(c => c.Type == "email").First().Value));
                                }
                            }

                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddAuthorization()
            .AddNewtonsoftJson()
            .AddApiExplorer();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Home";
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowMyOrigin");

            //DataBase comma treatment
            var usCulture = new CultureInfo("en-US");
            var supportedCultures = new[] { usCulture };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(usCulture),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Generate DataBase and update it from the last migration thats exists in 'Migrations' folder when run application.
            using (var scope =
                    app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var context = scope.ServiceProvider.GetService<ReclotiContext>())
                context.Database.Migrate();
        }
    }
}
