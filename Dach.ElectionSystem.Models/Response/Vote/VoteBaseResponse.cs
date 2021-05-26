using Dach.ElectionSystem.Models.Base;

namespace Dach.ElectionSystem.Models.Response.Vote
{
    /// <summary>
    /// Clase base para respuestas
    /// </summary>
    public class VoteBaseResponse : VoteBase
    {
        /// <summary>
        /// Estado de Voteo
        /// </summary>
        /// <value></value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Id de Voteo
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// Id de Evento
        /// </summary>
        /// <value></value>
        public int IdEvent { get; set; }

        /// <summary>
        /// Id de Candidato
        /// </summary>
        /// <value></value>
        public int IdCandidate { get; set; }

        /// <summary>
        /// Id de Usuario
        /// </summary>
        /// <value></value>
        public int IdUser { get; set; }
    }
}