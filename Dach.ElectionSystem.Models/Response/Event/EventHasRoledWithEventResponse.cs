namespace Dach.ElectionSystem.Models.Response.Event
{
    /// <summary>
    /// Clase EventGetResponse
    /// </summary>
    public class EventHasRoledWithEventResponse
    {
        /// <summary>
        /// Tiene relación con el evento?
        /// </summary>
        /// <value></value>
        public bool HasRelationshipEvent  { get; set; }

        /// <summary>
        /// Relación siendo Administrador
        /// </summary>
        /// <value></value>
        public bool AdmnistratorRelation  { get; set; }
        /// <summary>
        /// Relación siendo Candidato
        /// </summary>
        /// <value></value>
        public bool CandidateRelation  { get; set; }

        /// <summary>
        /// Relación siendo Participante
        /// </summary>
        /// <value></value>
        public bool ParticipantRelation  { get; set; }

    }
}