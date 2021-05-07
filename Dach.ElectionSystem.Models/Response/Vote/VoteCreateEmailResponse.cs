using System.Collections.Generic;
namespace Dach.ElectionSystem.Models.Response.Vote
{
    /// <summary>
    /// Clase VoteCreateEmailResponse
    /// </summary>
    public class VoteCreateEmailResponse
    {
        /// <summary>
        /// Lista de Correos de usuarios registrados
        /// </summary>
        /// <value></value>
        public List<string> EmailUserRegister { get; set; }
        
        /// <summary>
        /// Número de correos de Usuarios
        /// </summary>
        /// <value></value>
        public int NumberRegister { get; set; }

        /// <summary>
        /// Lista de Correos de usuarios no registrados
        /// </summary>
        /// <value></value>
        public List<string> EmailUserWithOutRegister { get; set; }

        /// <summary>
        /// Cantidad de Correos de usuarios no registrados
        /// </summary>
        /// <value></value>
        public int NumberSendEmail { get; set; }
    }
}
