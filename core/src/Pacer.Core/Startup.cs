using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pacer.Authentication.Cso;
using Pacer.Core.Models;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Pacer.Core
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            //services.AddCors();
            services.AddMvc();
            services.AddTransient<ICsoServer, PassingCsoServer>();

            // Add our repository type
            services.AddSingleton<ICaseRepository, CaseRepository>();

            services.AddSingleton<IConfiguration>(Configuration);
            //services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ICsoServer server)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var opt = new CsoOptions();
            opt.SetCsoServer(server);
            //Temporarily disable this
            //app.UseCsoAuthentication(opt);

            app.UseMvc();

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"pacerui")),
                RequestPath = new Microsoft.AspNetCore.Http.PathString("/pacerui")
            });
            //app.UseCors(builder =>
            //   builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


        }
    }
}
