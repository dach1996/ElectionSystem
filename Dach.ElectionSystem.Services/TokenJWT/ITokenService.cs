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
        string GenerateTokenJwt(string username);
        void ValidateToken(HttpContext context);
    }
}
