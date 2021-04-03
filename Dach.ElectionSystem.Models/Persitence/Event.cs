using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dach.ElectionSystem.Models.Persitence
{
    /// <summary>
    /// Clase de persistencia Eventos
    /// </summary>
    [Table(name: "EVENTOS")]
    public class Event
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Event()
        {
            this.IsActive = true;
            this.AdministratorEvent = new List<AdministratorEvent>();
            this.Group = new List<Group>();
        }
        #endregion
        
        #region Attributes

        /// <summary>
        /// Id de evento
        /// </summary>
        /// <value></value>
        [Key, Column("ID_EVENTO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Nombre evento
        /// </summary>
        /// <value></value>
        [Column("NOMBRE_EVENTO")]
        public string Name { get; set; }
        /// <summary>
        /// Dirección de foto de Evento
        /// </summary>
        /// <value></value>
        [Column("FOTO_EVENTO")]
        public string Image { get; set; }
        /// <summary>
        /// Descripción de Evento
        /// </summary>
        /// <value></value>
        [Column("DESCRIPCION_EVENTO")]
        public string Description { get; set; }
        /// <summary>
        /// Permitir  máximo de personas por evento
        /// </summary>
        /// <value></value>
        [Column("MAX_PERSONAS_EVENTO")]
        public bool MaxPeople { get; set; }
        /// <summary>
        /// Numero máximo de participantes
        /// </summary>
        /// <value></value>
        [Column("NUM_MAX_PERSONAS_EVENTO")]
        public int NumberMaxPeople { get; set; }
        /// <summary>
        /// Número máximo de candidatos
        /// </summary>
        /// <value></value>
        [Column("NUM_MAX_CANDIDATOS_EVENTO")]
        public int NumberMaxCandidate { get; set; }
        /// <summary>
        /// Categoría de Evento.
        /// </summary>
        /// <value></value>
        [Column("CATEGORIA")]
        public string Category { get; set; }

        /// <summary>
        /// Evento está Activo
        /// </summary>
        /// <value></value>
        [Column("ESTADO_EVENTO")]
        public bool IsActive { get; set; }
        #endregion
        
        #region Relations
        /// <summary>
        /// Eventos Usuarios
        /// </summary>
        /// <value></value>
        public ICollection<AdministratorEvent> AdministratorEvent { get; set; }

        /// <summary>
        /// Eventos Usuarios
        /// </summary>
        /// <value></value>
        public ICollection<Group> Group { get; set; }
        #endregion


    }
}
