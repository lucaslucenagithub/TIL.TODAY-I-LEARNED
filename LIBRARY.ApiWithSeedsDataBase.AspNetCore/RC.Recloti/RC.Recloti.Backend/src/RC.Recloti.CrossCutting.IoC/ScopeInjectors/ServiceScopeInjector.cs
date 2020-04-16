using Microsoft.Extensions.DependencyInjection;
using NLog;
using RC.Recloti.Business.Interfaces;
using RC.Recloti.Business.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RC.Recloti.CrossCutting.IoC.ScopeInjectors
{
    public static class ServiceScopeInjector
    {
        public static void Add(IServiceCollection services)
        {

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IProfileService, ProfileService>();
        }
    }
}
