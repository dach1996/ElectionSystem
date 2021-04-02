using Dach.ElectionSystem.Services.Data;
using Dach.ElectionSystem.Services.TokenJWT;
using Microsoft.Extensions.DependencyInjection;

namespace Dach.ElectionSystem.Services.Intrastructure
{
    public static class InitServices
    {
         public static void AddServices(this IServiceCollection services) {
                services.AddTransient<ITokenService, TokenService>();
                services.AddTransient<ValidateIntegrity, ValidateIntegrity>();
         }
    }
}