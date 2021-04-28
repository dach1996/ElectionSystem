using Dach.ElectionSystem.Models.RequestBase;
using MediatR;
namespace Dach.ElectionSystem.Models.Request.User
{
    /// <summary>
    /// Request para cambiar de contraseña
    /// </summary>
    public class ChangePasswordRequest : RequestBaseImpl, IRequest<Unit>
    {
        /// <summary>
        /// Nueva Contraseña
        /// </summary>
        /// <value></value>
        public string NewPassword { get; set; }
    }
}
