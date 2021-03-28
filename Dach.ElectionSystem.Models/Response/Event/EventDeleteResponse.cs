using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Response.Event
{
    /// <summary>
    /// Clase EventDeleteResponse
    /// </summary>
    public class EventDeleteResponse
    {
        /// <summary>
        /// Id de Evento
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        /// <summary>
        /// Nombre de Evento
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
    }
}
