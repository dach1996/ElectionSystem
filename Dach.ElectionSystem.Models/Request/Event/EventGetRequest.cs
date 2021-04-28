using System.ComponentModel.DataAnnotations;
using Dach.ElectionSystem.Models.Enums;
using Dach.ElectionSystem.Models.Request.Methods;
using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.Event;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.Event
{
    /// <summary>
    /// Clase Event Get Request
    /// </summary>
    public class EventGetRequest : RequestBaseImpl, IRequest<EventGetResponse>, IGetRequest
    {
        /// <summary>
        /// Id de Evento
        /// </summary>
        /// <value></value>
        public int? Id { get; set; }

        /// <summary>
        /// Paginación
        /// </summary>
        /// <value></value>
        [Required]
        [Range(0,int.MaxValue)]
        public int Offset { get; set; }

        /// <summary>
        /// Orden de Consulta
        /// </summary>
        /// <value></value>
        [Required]
        public OrderBy? OrderBy { get; set; }

        /// <summary>
        /// Cantidad de Registros
        /// </summary>
        /// <value></value>
        [Required]
        [Range(1,int.MaxValue)]
        public int Limit { get; set; }

        /// <summary>
        /// Nombre de evento
        /// </summary>
        /// <value></value>
        public string Name { get; set; }


        /// <summary>
        /// Categoría de Evento
        /// </summary>
        /// <value></value>
        public string Category { get; set; }
    }
}