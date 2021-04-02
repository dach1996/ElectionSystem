using Dach.ElectionSystem.Repository.DBContext;
using Dach.ElectionSystem.Repository.Intrastructure;
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
using Dach.ElectionSystem.Services.TokenJWT;
using Dach.ElectionSystem.Utils.Extension;
using System.Collections.Generic;
using Dach.ElectionSystem.Utils.Mapper;
using Dach.ElectionSystem.Utils.Mediator;
using Dach.ElectionSystem.Utils.Filters;
using Dach.ElectionSystem.Services.Intrastructure;

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
#if DEBUG
            services.AddDbContext<WebApiDbContext>(options => options.UseSqlServer("Server=DESKTOP-6PGT33F;Initial Catalog=ElectionSystem;Integrated Security=true; User Id=sa;Password=dach1996;")
            .EnableDetailedErrors().
            EnableSensitiveDataLogging());
#else
            services.AddDbContext<WebApiDbContext>(options => options.UseSqlServer("Server=SQL5103.site4now.net;Initial Catalog=DB_A49E05_electionSystem;User Id=DB_A49E05_electionSystem_admin;Password=dach1996"));
#endif
            services.AddRepositorys();
            services.AddServices();
            services.ConfigureController();

            services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema de Elecciones", Version = "v1" });
                 c.IncludeXmlComments("ElectionSystem.xml");
                 c.IncludeXmlComments("ElectionSystemModels.xml");


            });


         
        
            services.ConfigureSwaggerServices(new List<string> { "ElectionSystem.xml" });
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddAutoMapper(typeof(CustomMapperDTO));
            services.AddIMediaRServices();
            services.AddScoped<ModelFilter>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {


            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dach.ElectionSystem.WebApi v1"));
            app.SetCustomMiddleWare();
            app.UseHttpsRedirection();
            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
