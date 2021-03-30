namespace Dach.ElectionSystem.Models.Base
{
    /// <summary>
    /// Calse base para Evento
    /// </summary>
    public class EventBase
    {
        /// <summary>
        /// Id de Evento
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        
        /// <summary>
        /// Nombre de evento
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// Ruta de imagen para evento
        /// </summary>
        /// <value></value>
        public string Image { get; set; }
        /// <summary>
        /// Descripción de evento
        /// </summary>
        /// <value></value>
        public string Description { get; set; }
        /// <summary>
        /// Permitir máximo personas para Evento
        /// </summary>
        /// <value></value>
        public bool MaxPeople { get; set; }
        /// <summary>
        /// Número máximo de personas para evento
        /// </summary>
        /// <value></value>
        public int NumberMaxPeople { get; set; }
        /// <summary>
        /// Máximo de Candidatos
        /// </summary>
        /// <value></value>
        public int NumberMaxCandidate { get; set; }
        /// <summary>
        /// Categoría de Evento
        /// </summary>
        /// <value></value>
        public string Category { get; set; }
        /// <summary>
        /// Evento Activo
        /// </summary>
        /// <value></value>
        public bool? IsActive { get; set; }
    }
}