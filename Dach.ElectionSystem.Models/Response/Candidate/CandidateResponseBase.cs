using Dach.ElectionSystem.Models.Base;

namespace Dach.ElectionSystem.Models.Response.Candidate
{
    /// <summary>
    /// Clase base para respuesta de candidato
    /// </summary>
    public class CandidateResponseBase : CandidateBase
    {
        /// <summary>
        /// Id de candidato
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// Id de candidato
        /// </summary>
        /// <value></value>
        public bool IsActive { get; set; }

    }
}