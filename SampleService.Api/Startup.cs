using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SampleService.Common.Utility;
using SampleService.Repository.Utility;
using AutoMapper;
using SampleService.Service.Utility;
using NLog;
using NLog.Extensions.Logging;
using Autofac.Extensions.DependencyInjection;

namespace SampleService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            LogManager.Configuration = new NLogLoggingConfiguration(Configuration.GetSection("NLog"));
        }

        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // AddOptions
            // Session
            // AppInsights
            // AddRouting
            // AddControllers
            services.AddControllers();
            // AddHttpContextAccessor
            // AddMvc
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // CORS
            // Auth
            // Swagger
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ServiceAutofacModule());
            builder.RegisterModule(new CommonAutofacModule());
            builder.RegisterModule(new RepositoryAutofacModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Custom Middlewares
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            // Swagger
            // Session

            app.UseHttpsRedirection();

            app.UseRouting();
            // CORS
            // Auth
            app.UseAuthorization();
            // UseMvc

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
