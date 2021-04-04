using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Models.RequestBase;
using Microsoft.AspNetCore.Http;

namespace Dach.ElectionSystem.Services.TokenJWT
{
    public interface ITokenService
    {
        string GenerateTokenJwt(User user);
        void ValidateToken(HttpContext context);
        TokenModel GetTokenModel(HttpContext context);
    }
}
