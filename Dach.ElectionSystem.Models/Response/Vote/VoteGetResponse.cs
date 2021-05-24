using System.Collections.Generic;
using System.Linq;

namespace Dach.ElectionSystem.Models.Response.Vote
{
    /// <summary>
    /// Clase VoteGetResponse
    /// </summary>
    public class VoteGetResponse
    {
        /// <summary>
        /// Número de participantes sin votar
        /// </summary>
        /// <value></value>
        public int NumberParticipantsWithOutVote  { get;set; }

        /// <summary>
        /// Número de participantes que han votado
        /// </summary>
        /// <value></value>
        public int NumberParticipantsWithVote { get;set; }

        /// <summary>
        /// Número de participantes totales y contables
        /// </summary>
        /// <value></value>
        public int NumberParticipantsActive  { get;set; }

        /// <summary>
        /// Número de participantes eliminados o desactivados
        /// </summary>
        /// <value></value>
        public int NumberParticipantsDesactive { get;set; }

        /// <summary>
        /// Lista de Voteos
        /// </summary>
        /// <value></value>
        public List<VoteResponseBase> ListVotes { get; set; }
    }
}