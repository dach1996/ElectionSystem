using Dach.ElectionSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Dach.ElectionSystem.Models.ExceptionGeneric
{
    /// <summary>
    /// Clase personalizada Error
    /// </summary>
   [Serializable]
    public class ExceptionCustom : Exception
    {
        /// <summary>
        /// Código HTTP que se debe responder
        /// </summary>
        public HttpStatusCode CodeHttp { get; set; }

        /// <summary>
        /// Tipo de respuesta 
        /// </summary>
        public ResponseType ResponseType { get; set; }

        /// <summary>
        /// Código personalizado de error
        /// </summary>
        public MessageCodesApi MessageCodesApi { get; set; }

        
        /// <summary>
        /// Código personalizado de error
        /// </summary>
        public string MessageSpecific { get; set; }

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="codeHttp">Código de respuesta</param>
        /// <param name="messageCodesApi">Mensaje de respuesta</param>
        /// <param name="responseType">Tipo de respuesta</param>
        /// <param name="messageSpecific">Mensaje Específico</param>
        public ExceptionCustom(MessageCodesApi messageCodesApi,  ResponseType responseType, HttpStatusCode codeHttp, string messageSpecific="") :base()
        {
            CodeHttp = codeHttp;
            ResponseType = responseType;
            MessageCodesApi = messageCodesApi;
            MessageSpecific= messageSpecific;
        }

    }
}
