using System.Collections.Generic;

namespace Dach.ElectionSystem.Models.Response.Vote
{
    /// <summary>
    /// Clase VoteGetResponse
    /// </summary>
    public class VoteGetResponse
    {
        /// <summary>
        /// Lista de Voteos
        /// </summary>
        /// <value></value>
        public List<VoteResponseBase> ListVotes { get; set; }
        
        
    }
}