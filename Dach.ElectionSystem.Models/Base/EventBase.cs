using System;
using System.ComponentModel.DataAnnotations;

namespace Dach.ElectionSystem.Models.Base
{
    /// <summary>
    /// Calse base para Evento
    /// </summary>
    public abstract class EventBase
    {

        /// <summary>
        /// Nombre de evento
        /// </summary>
        /// <value></value>
        [Required]
        public virtual string Name { get; set; }

        /// <summary>
        /// Ruta de imagen para evento
        /// </summary>
        /// <value></value>

        public virtual string Image { get; set; }
        /// <summary>
        /// Descripción de evento
        /// </summary>
        /// <value></value>
        [Required]
        public virtual string Description { get; set; }

        /// <summary>
        /// Permitir máximo personas para Evento
        /// </summary>
        /// <value></value>
        
        [Required]
        public virtual bool MaxPeople { get; set; }
        /// <summary>
        /// Número máximo de personas para evento
        /// </summary>
        /// <value></value>
        
        [Required]
        [Range(0,Int32.MaxValue) ]
        public virtual int NumberMaxPeople { get; set; }
        /// <summary>
        /// Máximo de Candidatos
        /// </summary>
        /// <value></value>
        
        [Required]
        [Range(2,30) ]
        public virtual int NumberMaxCandidate { get; set; }
        
        /// <summary>
        /// Categoría de Evento
        /// </summary>
        /// <value></value>
        [Required]
        public virtual string Category { get; set; }
    }
}