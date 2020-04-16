using Microsoft.Extensions.DependencyInjection;
using RC.Recloti.Data.Repositories;
using RC.Recloti.Data.UoW;
using RC.Recloti.Domain.Interfaces.Repositories;
using RC.Recloti.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace RC.Recloti.CrossCutting.IoC.ScopeInjectors
{
    public static class RepositoryScopeInjector
    {
        public static void Add(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
        }
    }
}
