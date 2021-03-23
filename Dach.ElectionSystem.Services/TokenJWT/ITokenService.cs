using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Models.RequestBase;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Services.TokenJWT
{
    public interface ITokenService
    {
        string GenerateTokenJwt(User user);
        void ValidateToken(HttpContext context);
        TokenModel GetTokenModel(HttpContext context);
    }
}
