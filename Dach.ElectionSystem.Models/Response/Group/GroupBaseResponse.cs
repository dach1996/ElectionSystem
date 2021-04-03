using Dach.ElectionSystem.Models.Base;

namespace Dach.ElectionSystem.Models.Response.Group
{
    /// <summary>
    /// Clase Base GroupBaseResponse
    /// </summary>
    public class GroupBaseResponse : GroupBase
    {
        /// <summary>
        /// Estado de Grupo
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Ide de grupo
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
    }
}