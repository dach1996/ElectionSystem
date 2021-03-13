using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Dach.ElectionSystem.Models.Enums
{
    /// <summary>
    /// Mensages genéricos de error
    /// </summary>
    public enum  MessageCodesApi
    {
        /// <summary>
        /// Transacción exitosa
        /// </summary>
       [EnumMember(Value = "Requiere Token")]
        WithOutToken = 100,

        /// <summary>
        /// Error del sistema
        /// </summary>
        [EnumMember(Value = "Token Incorrecto")]
        InvalidToken = 101,

      /// <summary>
       /// Transacción exitosa
       /// </summary>
       [EnumMember(Value = "Error Inesperado")]
        ErrorGeneric = 600
    }
}
