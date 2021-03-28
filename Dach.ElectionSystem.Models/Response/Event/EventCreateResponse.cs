using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Response.Event
{
    /// <summary>
    /// Clase EventCreateResponse
    /// </summary>
    public class EventCreateResponse 
    {
        /// <summary>
        /// Id del evento
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        /// <summary>
        /// Nombre de Evento
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// Ruta Imagen del evento
        /// </summary>
        /// <value></value>
        public string Image { get; set; }
        /// <summary>
        /// Descripción de evento
        /// </summary>
        /// <value></value>
        public string Description { get; set; }
        /// <summary>
        /// Permitir máximo de personas
        /// </summary>
        /// <value></value>
        public bool MaxPeople { get; set; }
        /// <summary>
        /// Número máximo de personas
        /// </summary>
        /// <value></value>
        public int NumberMaxPeople { get; set; }
        /// <summary>
        /// Número máximo de candidatos
        /// </summary>
        /// <value></value>
        public int NumberMaxCandidate { get; set; }
        /// <summary>
        /// Categría de Evento
        /// </summary>
        /// <value></value>
        public string Category { get; set; }
    }
}
