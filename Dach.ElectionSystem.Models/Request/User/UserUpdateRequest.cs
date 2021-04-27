using Dach.ElectionSystem.Models.Response.User;
using MediatR;
using System.Text.Json.Serialization;


namespace Dach.ElectionSystem.Models.Request.User
{
    /// <summary>
    /// Clase Request para Update Usuario
    /// </summary>
    public class UserUpdateRequest : UserRequestBase, IRequest<UserUpdateResponse>
    {
        /// <summary>
        /// Email Usuario
        /// </summary>
        [JsonIgnore]
        private new string Email { get; set; }

        /// <summary>
        /// Constraseña de Usuario
        /// </summary>
        [JsonIgnore]
        private new string Password { get; set; }

        /// <summary>
        /// Número maximo de eventos permitidos
        /// </summary>
        [JsonIgnore]
        private int MaxEventsAllow { get; set; }

    }
}
