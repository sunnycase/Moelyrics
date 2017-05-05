using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Moelyrics.Web.Policies;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Moelyrics.Services.Metadata.Infrastructure;
using Autofac;
using Moelyrics.Services.Metadata.Api.Infrastructure.AutofacModules;
using Autofac.Extensions.DependencyInjection;
using System.IO;
using AutoMapper;

namespace Moelyrics.Web
{
    public class Startup
    {
        private readonly string _contentRoot;

        public Startup(IHostingEnvironment env)
        {
            _contentRoot = env.ContentRootPath;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddUserSecrets<Startup>()
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Moelyrics API", Version = "v1" });
            });
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
            services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicy", p => p.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());
                o.DefaultPolicyName = "AllowAllOrigins";
            });

            services.AddAuthorization(o =>
            {
                o.AddPolicy(AuthorizationPolicies.AcquireCreateNew, p => p.RequireRole("CreateNew"));
            });
            services.AddDbContext<AppDbContext>(builder =>
            {
                builder.UseSqlite(Configuration.GetConnectionString("appdb").Replace("|DataDirectory|", Path.Combine(_contentRoot, "Data")),
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                    });
            }, ServiceLifetime.Scoped);
            services.AddAutoMapper(typeof(Startup).GetTypeInfo().Assembly);

            var container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new MediatorModule());
            container.RegisterModule(new ApplicationModule());

            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
            }

            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint("/swagger/v1/swagger.json", "Moelyrics API");
            });
        }
    }
}
