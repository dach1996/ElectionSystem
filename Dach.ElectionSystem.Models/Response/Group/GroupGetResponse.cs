using System.Collections.Generic;

namespace Dach.ElectionSystem.Models.Response.Group
{
    /// <summary>
    /// Clase  GroupGetResponse
    /// </summary>
    public class GroupGetResponse  
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GroupGetResponse()
        {
            ListGroups = new  List<GroupBaseResponse>();
        }
        
        /// <summary>
        /// Lista de grupos
        /// </summary>
        /// <value></value>
        public List<GroupBaseResponse> ListGroups { get; set; }
        
        
    }
}