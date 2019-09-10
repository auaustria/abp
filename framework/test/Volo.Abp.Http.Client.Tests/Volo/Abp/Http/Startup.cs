﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Volo.Abp.Http
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<AbpHttpTestModule>(options =>
            {
                options.UseAutofac();
            });

            //TODO: This is needed because ASP.NET Core does not use IServiceProviderFactory!
            return services.BuildServiceProviderFromFactory();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}
