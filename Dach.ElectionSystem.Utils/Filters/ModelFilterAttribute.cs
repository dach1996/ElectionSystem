using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Services.Data;
using Dach.ElectionSystem.Services.TokenJWT;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Utils.Filters
{
    public class ModelFilterAttribute : ActionFilterAttribute
    {
        #region Constructor
        private readonly ITokenService tokenService;
        private readonly ValidateIntegrity validateIntegrity;

        public ModelFilterAttribute(ITokenService tokenService,
                            ValidateIntegrity validateIntegrity)
        {
            this.tokenService = tokenService;
            this.validateIntegrity = validateIntegrity;
        }
        #endregion

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
                var test = context.ActionDescriptor.Parameters;

            foreach (var parameterDescriptor in test)
            {
                var parameterInterfaces = parameterDescriptor.ParameterType.GetInterfaces();
                if (!parameterInterfaces.Any(t => t == typeof(IRequestBase))) continue;
                var modelContext = (IRequestBase)context.ActionArguments[parameterDescriptor.Name];
                modelContext.TokenModel = tokenService.GetTokenModel(context.HttpContext);
                modelContext.UserContext =  await validateIntegrity.ValidateUser(modelContext);
                modelContext.PathRoot = context.HttpContext.Request.Headers["Host"].ToString().Replace("www.","https://");
            }
            await base.OnActionExecutionAsync(context, next);
        }
    }

}
