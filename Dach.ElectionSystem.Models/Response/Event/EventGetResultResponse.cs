using System.Collections.Generic;
using Dach.ElectionSystem.Models.Response.Candidate;

namespace Dach.ElectionSystem.Models.Response.Event
{
    /// <summary>
    /// Clase EventGetResponse
    /// </summary>
    public class EventGetResultResponse
    {
        /// <summary>
        /// Total de Votos en el evento
        /// </summary>
        /// <value></value>
        public int TotalParticipantsVotes { get; set; }

        /// <summary>
        /// Total participantes sin votar
        /// </summary>
        /// <value></value>
        public int TotalParticipantsWithOutVotes { get; set; }

        /// <summary>
        /// Candidatas
        /// </summary>
        /// <value></value>
        public List<CandidateWithVote> Candidates { get; set; }

        /// <summary>
        /// Evento
        /// </summary>
        /// <value></value>
        public EventBaseResponse Event { get; set; }

    }

    /// <summary>
    /// Modelo para respuesta
    /// </summary>
    public class CandidateWithVote : CandidateBaseResponse
    {
        /// <summary>
        /// Cantidad de Votos
        /// </summary>
        /// <value></value>
        public int NumberVotes { get; set; }
    }
}