using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WoleServer.Common;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WoleServer.Api.Computer
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(actions =>
            {
                var corsPolicy = new CorsPolicy();

                corsPolicy.Headers.Add("*");
                corsPolicy.Methods.Add("*");
                corsPolicy.Origins.Add("*");
                actions.AddPolicy("pol", corsPolicy);
            });

            services.AddMvcCore()
                .AddJsonFormatters(settings =>
                {
                    settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
            services.AddAutoMapper();

            return services.AddDryIoc<Bootstrap>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            }

            app.UseCors("pol");
            app.UseMvc();
        }
    }
}
