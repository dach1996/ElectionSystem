using System;
using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.Response.Event;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.Event
{
    /// <summary>
    /// Clase EventUpdateRequest
    /// </summary>
    public class EventUpdateRequest : EventBaseRequest, IRequest<EventUpdateResponse>
    {
        /// <summary>
        /// Evento Activo
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Id de Evento
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int? Id { get; set; }

        /// <summary>
        /// Fecha registro
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public override DateTime DateRegister { get; set; }

    }
}