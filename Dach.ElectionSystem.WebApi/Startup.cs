using Dach.ElectionSystem.Repository.DBContext;
using Dach.ElectionSystem.Repository.Intrastructure;
using Dach.ElectionSystem.Utils.MiddlewareHandler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using Dach.ElectionSystem.Utils.Extension;
using Dach.ElectionSystem.Utils.Mapper;
using Dach.ElectionSystem.Utils.Filters;
using Dach.ElectionSystem.Services.Intrastructure;
using Dach.ElectionSystem.BusinessLogic.Auth;
using System;
using Microsoft.ApplicationInsights;
using System.IO;

namespace Dach.ElectionSystem.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
                        {
                            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
                               {
                                   builder.AllowAnyOrigin()
                                          .AllowAnyMethod()
                                          .AllowAnyHeader();
                               }));

                        });
            services.AddDbContext<WebApiDbContext>(options =>
            {
                options.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_SQL"),
                o =>
                {
                    o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    o.CommandTimeout(60);
                });

            });
            services.AddRepositorys();
            services.AddServices();
            services.ConfigureController();
            services.AddApplicationInsightsTelemetry();
            services.AddLogging(loggingBuilder =>
             {
                 loggingBuilder.AddSeq(Configuration.GetSection("Seq"));
                 loggingBuilder.AddFile(Configuration.GetSection("LogConfiguration"));
             });
            services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema de Elecciones", Version = "v1" });
                 c.IncludeXmlComments($"{AppContext.BaseDirectory}ElectionSystem.xml");
                 c.IncludeXmlComments($"{AppContext.BaseDirectory}ElectionSystemModels.xml");
             });
            services.ConfigureSwaggerServices();
            services.AddMediatR(typeof(AuthHandler));
            services.AddAutoMapper(typeof(CustomMapperDto));
            services.AddScoped<ModelFilterAttribute>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Sistema de Eleccione");
                c.RoutePrefix = string.Empty;
            });
            app.UseRouting();
            app.UseHttpsRedirection();
            app.SetCustomMiddleWare();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
