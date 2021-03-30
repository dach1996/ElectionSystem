using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Request.Event
{
    /// <summary>
    /// Clase EventDeleteRequest
    /// </summary>
     public class EventDeleteRequest : IRequestBase, IRequest<EventDeleteResponse>
    {
         /// <summary>
        /// Id de Evento
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Token Model
        /// </summary>
        [JsonIgnore]
        public TokenModel TokenModel { get; set ; }
    }
}
