using System.Runtime.Serialization;

namespace Dach.ElectionSystem.Models.Enums
{
    /// <summary>
    /// Selección de registros
    /// </summary>
    public enum TypeFilterUser
    {
        /// <summary>
        /// Todos los registros
        /// </summary>
        [EnumMember(Value = "Todos")]
        All = 0,

        /// <summary>
        /// Mis registros
        /// </summary>
        [EnumMember(Value = "Mios")]
        Mine = 1,
    }
}