using Dach.ElectionSystem.Models.Response.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Request.Event
{
    /// <summary>
    /// Clase EventCreateRequest
    /// </summary>
     public class EventCreateRequest : IRequest<EventCreateResponse>
    {
        /// <summary>
        /// Nombre de evento
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// Ruta de imagen para evento
        /// </summary>
        /// <value></value>
        public string Image { get; set; }
        /// <summary>
        /// Descripción de evento
        /// </summary>
        /// <value></value>
        public string Description { get; set; }
        /// <summary>
        /// Permitir máximo personas para Evento
        /// </summary>
        /// <value></value>
        public bool MaxPeople { get; set; }
        /// <summary>
        /// Número máximo de personas para evento
        /// </summary>
        /// <value></value>
        public int NumberMaxPeople { get; set; }
        /// <summary>
        /// Máximo de Candidatos
        /// </summary>
        /// <value></value>
        public int NumberMaxCandidate { get; set; }
        /// <summary>
        /// Categoría de Evento
        /// </summary>
        /// <value></value>
        public string Category { get; set; }
    }
}
