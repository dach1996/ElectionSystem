namespace Dach.ElectionSystem.Models.Base
{
    /// <summary>
    /// Clase base para grupo
    /// </summary>
    public class GroupBase
    {

        /// <summary>
        /// Nombre de Grupo
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// Detalles de grupo
        /// </summary>
        /// <value></value>
        public string Details { get; set; }

        /// <summary>
        /// Máximo de candidatos por grupo
        /// </summary>
        public int MaxCandidate { get; set; }

        /// <summary>
        /// Ruta de imágen para grupo
        /// </summary>
        /// <value></value>
        public string Image { get; set; }
    }
}