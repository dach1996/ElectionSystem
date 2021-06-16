using Dach.ElectionSystem.Models.Log;
using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Services.Data;
using Dach.ElectionSystem.Services.TokenJWT;
using Dach.ElectionSystem.Utils.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Utils.Filters
{
    public class ModelFilterAttribute : ActionFilterAttribute
    {
        #region Constructor
        private readonly ITokenService _tokenService;
        private readonly ValidateIntegrity _validateIntegrity;
        private readonly ILogger<ModelFilterAttribute> _logger;

        public ModelFilterAttribute(ITokenService tokenService,
                            ValidateIntegrity validateIntegrity,
                            ILogger<ModelFilterAttribute> logger)
        {
            _tokenService = tokenService;
            _validateIntegrity = validateIntegrity;
            _logger = logger;
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
                _ = Task.Run(() =>
                  {
                      LoggerRequest(new LogRequestModel()
                      {
                          LogMessage = "Request",
                          ModelToLog = modelContext
                      });
                  }
               );
                modelContext.TokenModel = _tokenService.GetTokenModel(context.HttpContext);
                modelContext.UserContext = await _validateIntegrity.ValidateUser(modelContext);
                modelContext.PathRoot = context.HttpContext.Request.Headers["Host"].ToString().Replace("www.", "https://");
            }
            await base.OnActionExecutionAsync(context, next);
        }

        /// <summary>
        /// Envia a Logear el Request 
        /// </summary>
        /// <param name="logRequestModel"></param>
        private void LoggerRequest(LogRequestModel logRequestModel)
        {
            try
            {
                 var jsonRequest = JsonConvert.SerializeObject(logRequestModel.ModelToLog,
             new JsonSerializerSettings { ContractResolver = new JsonPropertiesResolver()});
            _logger.Log(LogLevel.Warning, "{LogMessage}: {@Model}", logRequestModel.LogMessage, jsonRequest);
            }
            catch (System.Exception)
            {
                _logger.Log(LogLevel.Warning, "{LogMessage}: {@Model}");
            }  
        }
    }

}
