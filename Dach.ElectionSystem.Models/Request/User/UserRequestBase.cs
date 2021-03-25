using Dach.ElectionSystem.Models.Base;
using Dach.ElectionSystem.Models.RequestBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Request.User
{
    /// <summary>
    /// Base de Modelo
    /// </summary>
    public abstract class UserRequestBase : UserBase, IRequestBase
    {
        /// <summary>
        /// Token Base
        /// </summary>
        [JsonIgnore]
        public TokenModel TokenModel { get; set; }
    }
}
