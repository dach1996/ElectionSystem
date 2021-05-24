using System;
using System.ComponentModel.DataAnnotations;

using Dach.ElectionSystem.Models.Enums;
using Dach.ElectionSystem.Models.Request.Methods;
using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.Vote;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.Vote
{
    /// <summary>
    /// Clase Model para User Get Request
    /// </summary>
    public class VoteGetRequest : RequestBaseImpl, IRequest<VoteGetResponse>, IGetRequest
    {
        /// <summary>
        /// Id del EVento
        /// </summary>
        /// <value></value>
        public int IdEvent { get; set; }

        /// <summary>
        /// Paginación
        /// </summary>
        /// <value></value>
        [Required]
        [Range(0, int.MaxValue)]
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
        [Range(1, int.MaxValue)]
        public int Limit { get; set; }


    }
}