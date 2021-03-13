using Common.WebApi.Middleware;
using Dach.ElectionSystem.Repository.DBContext;
using Dach.ElectionSystem.Repository.Intrastructure;
using Dach.ElectionSystem.Services.Logger;
using Dach.ElectionSystem.Utils.Log;
using Dach.ElectionSystem.Utils.MiddlewareHandler;
using Dach.ElectionSystem.Utils.Segurity.JWT;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema de Elecciones", Version = "v1" });
                c.IncludeXmlComments("ElectionSystem.xml");
            });
            services.AddDbContext<WebApiDbContext>(options => options.UseSqlServer("Server=DESKTOP-M167ESR ;Initial Catalog=ElectionSystemDb;Integrated Security=true; User Id=sa;Password=dach1996;"));
            services.AddSingletonRepository();
            services.AddSingleton<ILoggerCustom,LoggerCustom>();
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
