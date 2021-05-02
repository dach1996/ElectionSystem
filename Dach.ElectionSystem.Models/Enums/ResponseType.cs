using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dach.ElectionSystem.Models.Enums
{
    /// <summary>
    /// Tipo de respuesta
    /// </summary>
    [Serializable]
    public enum ResponseType
    {
        ///<summary>
        /// Informativa
        /// </summary>
        Data,
        ///<summary>
        /// Error
        /// </summary>
        Error
    }
}
