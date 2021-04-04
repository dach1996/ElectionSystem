using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Utils.Extension
{
    public static class SwaggerExtension
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
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = "BasicAuth",
                        Type = ReferenceType.SecurityScheme
                    }

                };
                c.AddSecurityDefinition(bearerSecurityScheme.Reference.Id, bearerSecurityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        bearerSecurityScheme,
                        new List<string>()
                    }
                });
                c.DocumentFilter<SwaggerIgnoreFilter>();
            });


        }
        public class SwaggerIgnoreFilter : IDocumentFilter
        {
            public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
            {
                foreach (var path in swaggerDoc.Paths)
                {
                    foreach (var operation in path.Value.Operations)
                    {
                        var parameters = operation.Value.Parameters.ToList();
                        foreach (var parameter in parameters)
                        {
                            if (parameter.Name.StartsWith("TokenModel"))
                                operation.Value.Parameters.Remove(parameter);
                            if (parameter.Name.ToUpper().StartsWith("ID") &&
                            (operation.Key == OperationType.Get
                            || operation.Key == OperationType.Delete )&&
                             parameter.In == ParameterLocation.Query)
                                operation.Value.Parameters.Remove(parameter);
                            if (parameter.Name.StartsWith("UserContext"))
                                operation.Value.Parameters.Remove(parameter);
                        }
                    }
                }
            }
        }
    }
}
