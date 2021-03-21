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
        /// Error del sistema
        /// </summary>
        [EnumMember(Value = "Modelo de datos Invalido")]
        ModelInvalid = 150,
        /// <summary>
        /// Error del sistema
        /// </summary>
        [EnumMember(Value = "No se pudo crear registro")]
        NotCreateRecord = 300,
        /// <summary>
        /// Error del sistema
        /// </summary>
        [EnumMember(Value = "No se pudo encontrar registro")]
        NotFindRecord = 301,

        /// <summary>
        /// Error del sistema
        /// </summary>
        [EnumMember(Value = "No se pudo Actualizar registro")]
        NotUpdateRecord = 302,

        /// <summary>
        /// Error del sistema
        /// </summary>
        [EnumMember(Value = "No se pudo Eliminar registro")]
        NotDeleteRecord = 303,

        /// <summary>
        /// Transacción exitosa
        /// </summary>
        [EnumMember(Value = "Error Inesperado")]
        ErrorGeneric = 600
    }
}
