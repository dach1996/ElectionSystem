using System.Collections.Generic;
using Dach.ElectionSystem.Models.Base;
using Dach.ElectionSystem.Models.Response.User;

namespace Dach.ElectionSystem.Models.Response.Candidate
{
    /// <summary>
    /// Clase base para respuesta de candidato
    /// </summary>
    public class CandidateBaseResponse : CandidateBase
    {
        /// <summary>
        /// Id de candidato
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// Id del Usuario
        /// </summary>
        /// <value></value>
        public int IdUser { get; set; }

        /// <summary>
        /// Id de candidato
        /// </summary>
        /// <value></value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Lista de Imágenes
        /// </summary>
        /// <value></value>
        public IList<string> ListCandidateImage { get; set; }

        /// <summary>
        /// Usuario Correspondiente a candidato
        /// </summary>
        /// <value></value>
        public UserBaseResponse User { get; set; }
    }
}