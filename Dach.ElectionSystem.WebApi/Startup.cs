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
using Dach.ElectionSystem.Utils.Extension;
using Dach.ElectionSystem.Utils.Mapper;
using Dach.ElectionSystem.Utils.Filters;
using Dach.ElectionSystem.Services.Intrastructure;
using Dach.ElectionSystem.BusinessLogic.Auth;
using System;

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
            services.AddDbContext<WebApiDbContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_SQL")));
            services.AddRepositorys();
            services.AddServices();
            services.ConfigureController();

            services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema de Elecciones", Version = "v1" });
                 c.IncludeXmlComments("ElectionSystem.xml");
                 c.IncludeXmlComments("ElectionSystemModels.xml");



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
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Sistema de Eleccione"));
             app.UseHttpsRedirection();
            app.SetCustomMiddleWare();
           
            
            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
