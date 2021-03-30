using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Services.TokenJWT;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
namespace Dach.ElectionSystem.Utils.Filters
{
    public class ModelFilter : ActionFilterAttribute
    {
        private readonly ITokenService tokenService;

        public ModelFilter(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var test = context.ActionDescriptor.Parameters;

            foreach (var parameterDescriptor in test)
            {
                var parameterInterfaces = parameterDescriptor.ParameterType.GetInterfaces();
                if (!parameterInterfaces.Any(t => t == typeof(IRequestBase))) continue;
                var modelContext = (IRequestBase)context.ActionArguments[parameterDescriptor.Name];
                modelContext.TokenModel = tokenService.GetTokenModel(context.HttpContext);
            }
                base.OnActionExecuting(context);
        }
    }

}
