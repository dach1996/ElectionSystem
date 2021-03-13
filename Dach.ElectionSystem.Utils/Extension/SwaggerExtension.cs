using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Utils.Extension
{
   public static  class SwaggerExtension
    {
        public static void ConfigureSwaggerServices(this IServiceCollection services, List<string> documentationFiles)
        {
          
            services.AddSwaggerGen(c =>
            {
                var bearerSecurityScheme = new OpenApiSecurityScheme
                {
                    Description = "Token de autorización. \r\n\r\n Ingresa 'Bearer' [space] y luego el token de acceso.\r\n\r\nEjemplo: \"Bearer xxxxx123456789abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                };

  
                c.AddSecurityDefinition("Bearer", bearerSecurityScheme);

            });
        }

    }
}
