using System.ComponentModel;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.Enums;
using Dach.ElectionSystem.Models.Request.Methods;
using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.User;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.User
{
    /// <summary>
    /// Clase Model para User Get Request
    /// </summary>
    public class UserGetRequest : IRequestBase, IRequest<UserGetResponse>, IGetRequest
    {
        /// <summary>
        /// Id de Usuario
        /// </summary>
        /// <value></value>
        public int? Id { get; set; }
        /// <summary>
        /// Nick de Usuario
        /// </summary>
        /// <value></value>
        public string Username { get; set; }
        /// <summary>
        /// Nombre Usuario
        /// </summary>
        /// <value></value>
        public string FirstName { get; set; }
        /// <summary>
        /// Apellido Usuario
        /// </summary>
        /// <value></value>
        public string LastName { get; set; }
        /// <summary>
        /// Rol de Usuario
        /// </summary>
        /// <value></value>
        public Models.Enums.RolUser? Role { get; set; }
        /// <summary>
        /// Token Contexto
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public TokenModel TokenModel { get; set; }
        /// <summary>
        /// Contexto de Usuario
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public Persitence.User UserContext { get; set; }

        /// <summary>
        /// Path de server
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public string PathRoot { get; set; }


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
        [DefaultValue(100)]
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

        /// <summary>
        /// Tipo de Filtros
        /// </summary>
        /// <value></value>
        public TypeFilterUser TypeFilter { get; set; }

    }
}