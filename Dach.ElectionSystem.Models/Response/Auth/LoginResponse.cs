using Dach.ElectionSystem.Models.Response.User;

namespace Dach.ElectionSystem.Models.Response.Auth
{
    /// <summary>
    /// Clase LoginResponse
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Respuesta Token
        /// </summary>
        /// <value></value>
        public string Token { get; set; }

        /// <summary>
        /// Usuario
        /// </summary>
        /// <value></value>
        public UserBaseResponse User { get; set; }
    }
}
