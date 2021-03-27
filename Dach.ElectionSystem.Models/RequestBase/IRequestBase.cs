using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.RequestBase
{
    /// <summary>
    /// Clase base para todos los request
    /// </summary>
    public interface IRequestBase
    {
        /// <summary>
        /// Token para contexto
        /// </summary>
       [JsonIgnore]
        TokenModel TokenModel { get; set; }
    }
}
