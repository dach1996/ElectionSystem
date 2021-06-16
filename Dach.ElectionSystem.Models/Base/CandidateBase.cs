using System.Collections.Generic;
namespace Dach.ElectionSystem.Models.Base
{
    /// <summary>
    /// Clase base para candidato
    /// </summary>
    public class CandidateBase
    {
        /// <summary>
        /// Información Adicional
        /// </summary>
        /// <value></value>
        public Dictionary<string,object> AdditionalInformation { get; set; }
    }
}