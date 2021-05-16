using Dach.ElectionSystem.Models.Base;
using Dach.ElectionSystem.Models.RequestBase;
using System.Text.Json.Serialization;


namespace Dach.ElectionSystem.Models.Request.Vote
{
    /// <summary>
    /// Base de Modelo
    /// </summary>
    public abstract class VoteBaseRequest : VoteBase, IRequestBase
    {
        /// <summary>
        /// Contexto de Token
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

        /// <summary>
        /// Id de Evento
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int IdEvent { get; set; }

        /// <summary>
        /// Path de server
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public string PathRoot { get; set; }
    }
}
