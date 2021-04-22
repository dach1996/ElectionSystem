using System;
using Dach.ElectionSystem.Models.Base;

namespace Dach.ElectionSystem.Models.Response.EventAdministrator
{
    /// <summary>
    /// Clase base para respuestas
    /// </summary>
    public class EventAdministratorResponseBase : EventAdministratorBase
    {
        /// <summary>
        /// Estado de EventAdministratoro
        /// </summary>
        /// <value></value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Id Usuario
        /// </summary>
        /// <value></value>
        public int IdUser { get; set; }

        /// <summary>
        /// Id Evento
        /// </summary>
        /// <value></value>
        public int IdEvent { get; set; }

        /// <summary>
        /// Fecha de Cambio
        /// </summary>
        /// <value></value>
        public DateTime Date { get; set; }
        
        
    }
}