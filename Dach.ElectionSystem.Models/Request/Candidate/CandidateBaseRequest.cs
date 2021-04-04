using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.Base;
using Dach.ElectionSystem.Models.RequestBase;

namespace Dach.ElectionSystem.Models.Request.Candidate
{
    /// <summary>
    /// Clase  Base para Request de candidatos
    /// </summary>
    public class CandidateBaseRequest : CandidateBase, IRequestBase
    {
        /// <summary>
        /// Token Model
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public TokenModel TokenModel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public Persitence.User UserContext { get; set; }
    }
}