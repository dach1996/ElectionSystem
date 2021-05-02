using Dach.ElectionSystem.Models.RequestBase;
using MediatR;
namespace Dach.ElectionSystem.Models.Request.User
{
    /// <summary>
    /// Request para cambiar de contraseña
    /// </summary>
    public class IncreaseEventsRequest : RequestBaseImpl, IRequest<Unit>
    {
        /// <summary>
        /// Usuario para el servicio
        /// </summary>
        /// <value></value>
        public string UserToService { get; set; }

        /// <summary>
        /// Passwrod para el servicio
        /// </summary>
        /// <value></value>
        public string PasswordToService { get; set; }

        /// <summary>
        /// Id de usuario a incrementar
        /// </summary>
        /// <value></value>
        public int IdUserToIncreaseEvent { get; set; }

        /// <summary>
        /// Número de Eventos
        /// </summary>
        /// <value></value>
        public int NumberEvent { get; set; }
    }
}
