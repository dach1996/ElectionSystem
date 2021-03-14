using Dach.ElectionSystem.Repository.DBContext;
using Dach.ElectionSystem.Repository.Intrastructure;
using Dach.ElectionSystem.Services.Logger;
using Dach.ElectionSystem.Utils.MiddlewareHandler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MediatR;
using Dach.ElectionSystem.BusinessLogic;
using Dach.ElectionSystem.Utils.Segurity.JWT;
using Autofac;
using Dach.ElectionSystem.Services.TokenJWT;
using Dach.ElectionSystem.Utils.Extension;
using System.Collections.Generic;
using Dach.ElectionSystem.BusinessLogic.Auth;
using Dach.ElectionSystem.BusinessLogic.Event;
using Dach.ElectionSystem.Models.Auth;
using Dach.ElectionSystem.Models.Response.Auth;
using Dach.ElectionSystem.Models.Response.Event;
using Dach.ElectionSystem.Models.Request.Event;
using AutoMapper;
using Dach.ElectionSystem.Utils.Mapper;
using Dach.ElectionSystem.Utils.Mediator;

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

            services.AddDbContext<WebApiDbContext>(options => options.UseSqlServer("Server=DESKTOP-M167ESR ;Initial Catalog=ElectionSystemDb;Integrated Security=true; User Id=sa;Password=dach1996;"));
            services.AddSingletonRepository();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema de Elecciones", Version = "v1" });
                c.IncludeXmlComments("ElectionSystem.xml");
            });
            services.AddSingleton<ILoggerCustom, LoggerCustom>();
            services.AddSingleton<ITokenService, TokenService>();
            services.ConfigureSwaggerServices(new List<string> { "ElectionSystem.xml" });
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddAutoMapper(typeof(CustomMapperDTO));
            services.AddIMediaRServices();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dach.ElectionSystem.WebApi v1"));

            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.SetCustomMiddleWare();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
