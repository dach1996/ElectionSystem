using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.User;
using MediatR;
using Newtonsoft.Json;

namespace Dach.ElectionSystem.Models.Request.User
{
    /// <summary>
    /// Clase para Request Delete User
    /// </summary>
    public class UserDeleteRequest : IRequestBase, IRequest<UserDeleteResponse>
    {
        /// <summary>
        /// Id de usuario
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Token Model
        /// </summary>
        [JsonIgnore]
        public TokenModel TokenModel { get; set ; }
    }
}
