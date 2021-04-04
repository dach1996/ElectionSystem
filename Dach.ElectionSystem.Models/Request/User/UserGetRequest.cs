
using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.User;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.User
{
    /// <summary>
    /// Clase Model para User Get Request
    /// </summary>
    public class UserGetRequest : IRequestBase, IRequest<UserGetResponse>
    {
        /// <summary>
        /// Id de Usuario
        /// </summary>
        /// <value></value>
        public int? Id { get; set; }
        /// <summary>
        /// Nick de Usuario
        /// </summary>
        /// <value></value>
        public string Username { get; set; }
        /// <summary>
        /// Nombre Usuario
        /// </summary>
        /// <value></value>
        public string FirstName { get; set; }
        /// <summary>
        /// Apellido Usuario
        /// </summary>
        /// <value></value>
        public string LastName { get; set; }
        /// <summary>
        /// Rol de Usuario
        /// </summary>
        /// <value></value>
        public Models.Enums.RolUser? Role { get; set; }
        /// <summary>
        /// Token Contexto
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public TokenModel TokenModel { get; set; }
              /// <summary>
        /// Contexto de Usuario
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public Persitence.User UserContext { get; set; }
    }
}