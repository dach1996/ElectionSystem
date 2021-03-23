using System.Runtime.Serialization;

namespace Dach.ElectionSystem.Models.Enums
{
    /// <summary>
    /// Rol from Users
    /// </summary>
    public enum RolUser
    {
        /// <summary>
        /// Rol SuperAdmin
        /// </summary>
        [EnumMember(Value = "SUPER ADMINISTRADOR")]
        SuperAdmin = 1,
        /// <summary>
        /// Rol Administrator
        /// </summary>
        [EnumMember(Value = "ADMINISTRADOR")]
        Admin = 2,
        /// <summary>
        /// Rol User
        /// </summary>
        [EnumMember(Value = "USUARIO")]
        User = 3,

    }
}
