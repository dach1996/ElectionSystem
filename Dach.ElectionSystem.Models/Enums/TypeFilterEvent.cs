using System.Runtime.Serialization;

namespace Dach.ElectionSystem.Models.Enums
{
    /// <summary>
    /// Selección de registros
    /// </summary>
    public enum TypeFilterEvent
    {
        /// <summary>
        /// Todos los registros
        /// </summary>
        [EnumMember(Value = "Todos")]
        All = 0,

        /// <summary>
        /// Mis registros
        /// </summary>
        [EnumMember(Value = "Mios")]
        Mine = 1,

        /// <summary>
        /// Mis registros
        /// </summary>
        [EnumMember(Value = "Soy Administrador")]
        Administrator = 2,

        /// <summary>
        /// Mis eventos que he votado
        /// </summary>
        [EnumMember(Value = "Tengo registro de voto")]
        MineWithVote = 3,

        /// <summary>
        /// Mis eventos sin votar
        /// </summary>
        [EnumMember(Value = "No tengo registro de voto")]
        MineWithOutVote = 4,

        /// <summary>
        /// Soy candidato
        /// </summary>
        [EnumMember(Value = "Soy candidato en el evento")]
        Candidate = 5,

        /// <summary>
        /// Soy Participante
        /// </summary>
        [EnumMember(Value = "Soy participante en el evento")]
        Participant = 6,

        /// <summary>
        /// Relación
        /// </summary>
        [EnumMember(Value = "Tengo relación con el Evento")]
        Relation = 7,
    }
}