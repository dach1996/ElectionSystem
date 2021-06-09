using Dach.ElectionSystem.Models.Base;
using Dach.ElectionSystem.Models.Response.User;

namespace Dach.ElectionSystem.Models.Response.Event
{
    /// <summary>
    /// Clase base para respuestas
    /// </summary>
    public class EventBaseResponse : EventBase
    {
        /// <summary>
        /// Estado de Evento
        /// </summary>
        /// <value></value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Id de Evento
        /// </summary>
        /// <value></value>
        public int Id { get; set; }


        /// <summary>
        /// CódigoEvento
        /// </summary>
        /// <value></value>
        public string CodeEvent { get; set; }

        /// <summary>
        /// Usuario
        /// </summary>
        /// <value></value>
        public UserBaseResponse User { get; set; }

    }
}