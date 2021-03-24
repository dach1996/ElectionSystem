using Dach.ElectionSystem.Models.ResponseBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Utils.Extension
{
    public static class ControllerExtension
    {
        public static void ConfigureController(this IServiceCollection services)
        {
            services.AddControllers().ConfigureApiBehaviorOptions(opt =>
            {
                opt.InvalidModelStateResponseFactory = context =>
                {
                    var errorList = context.ModelState.ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                    var response = new GenericResponse<Dictionary<string, string[]>>
                    {
                        Code = (int)Models.Enums.MessageCodesApi.ModelInvalid,
                        ResponseType = Models.Enums.ResponseType.Error.GetEnumMember(),
                        Content = errorList,
                        Message = Models.Enums.MessageCodesApi.ModelInvalid.GetEnumMember()
                    };
                    var result = new BadRequestObjectResult(response);
                    result.ContentTypes.Add(MediaTypeNames.Application.Json);
                    return result;
                };
            }
            ).AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); ;
        }
    }
}
