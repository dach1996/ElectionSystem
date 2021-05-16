using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.Base;
using Dach.ElectionSystem.Models.RequestBase;

namespace Dach.ElectionSystem.Models.Request.EventAdministrator
{
    /// <summary>
    /// Clase base para Request de EventAdministratoro
    /// </summary>
    public class EventAdministratorBaseRequest : EventAdministratorBase, IRequestBase
    {


        /// <summary>
        /// Id Usuario
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int IdUser { get; set; }


        /// <summary>
        /// Id Evento
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int IdEvent { get; set; }

        /// <summary>
        /// Clase contexto de Token
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
        /// Path de server
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public string PathRoot { get; set; }
    }
}