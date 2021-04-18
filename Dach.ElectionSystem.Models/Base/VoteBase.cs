using System;

namespace Dach.ElectionSystem.Models.Base
{
    /// <summary>
    /// Clase base para Votos
    /// </summary>
    public class VoteBase
    {
         /// <summary>
        /// Cédula Usuario
        /// </summary>
        public virtual DateTime Date { get; set; }

        /// <summary>
        /// Cédula Usuario
        /// </summary>
        public virtual bool HasVote { get; set; }
    }
}