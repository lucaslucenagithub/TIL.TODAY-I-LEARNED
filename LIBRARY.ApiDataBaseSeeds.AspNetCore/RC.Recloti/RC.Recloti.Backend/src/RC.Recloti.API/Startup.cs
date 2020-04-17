using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RC.Recloti.CrossCutting.IoC;
using NLog;

namespace RC.Recloti.Api
{
    public class Startup : NativeInjectorBootStrapper
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
