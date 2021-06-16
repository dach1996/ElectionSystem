using System.Collections.Generic;
using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.Base;
using Dach.ElectionSystem.Models.RequestBase;

namespace Dach.ElectionSystem.Models.Request.Candidate
{
    /// <summary>
    /// Clase  Base para Request de candidatos
    /// </summary>
    public class CandidateBaseRequest : IRequestBase
    {
        /// <summary>
        /// Token Model
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public TokenModel TokenModel { get; set; }

        /// <summary>
        /// Contexto de usuario
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public Persitence.User UserContext { get; set; }


       /// <summary>
        /// Path de server
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public string PathRoot { get; set; }

        /// <summary>
        /// Información Adicional
        /// </summary>
        /// <value></value>
        public Dictionary<string,object> AdditionalInformation { get; set; }
    }
}