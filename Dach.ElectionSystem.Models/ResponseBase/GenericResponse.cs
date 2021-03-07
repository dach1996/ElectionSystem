using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Dach.ElectionSystem.Models.ResponseBase
{
    /// <summary>
    /// Respuesta genérica
    /// </summary>
    public class GenericResponse<T>
    {

        /// <summary>
        /// Código de respuesta
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Response type
        /// </summary>
        public string ResponseType { get; set; }

        /// <summary>
        /// Mensaje al usuario
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Información de vuelta al usuario
        /// </summary>
        public T Content { get; set; }

        /// <summary>
        /// Get a serialized Generic response class
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            return JsonSerializer.Serialize(this, options);
        }
    }
}
