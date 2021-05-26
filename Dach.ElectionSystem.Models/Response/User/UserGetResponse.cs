using System.Collections.Generic;

namespace Dach.ElectionSystem.Models.Response.User
{
    /// <summary>
    /// Clase Modelo para Get User Response
    /// </summary>
    public class UserGetResponse 
    {
        /// <summary>
        /// Lista de Usuario
        /// </summary>
        /// <value></value>
        public List<UserBaseResponse> ListUser { get; set; }
    }
}