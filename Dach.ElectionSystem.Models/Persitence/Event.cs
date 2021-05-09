using System;
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
            this.ListEventAdministrator = new List<EventAdministrator>();
            this.ListVote = new List<Vote>();
            this.ListCandidate = new List<Candidate>();

        }
        #endregion

        #region Attributes

        /// <summary>
        /// Id de evento
        /// </summary>
        /// <value></value>
        [Key, Column("EVT_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Nombre evento
        /// </summary>
        /// <value></value>
        [Column("EVT_NOMBRE")]
        public string Name { get; set; }
        /// <summary>
        /// Dirección de foto de Evento
        /// </summary>
        /// <value></value>
        [Column("EVT_FOTO")]
        public string Image { get; set; }
        /// <summary>
        /// Descripción de Evento
        /// </summary>
        /// <value></value>
        [Column("EVT_DESCRIPCION")]
        public string Description { get; set; }
        /// <summary>
        /// Permitir  máximo de personas por evento
        /// </summary>
        /// <value></value>
        [Column("EVT_MAX_PERSONAS")]
        public bool MaxPeople { get; set; }
        /// <summary>
        /// Numero máximo de participantes
        /// </summary>
        /// <value></value>
        [Column("EVT_NUM_MAX_PERSONAS")]
        public int NumberMaxPeople { get; set; }
        /// <summary>
        /// Número máximo de candidatos
        /// </summary>
        /// <value></value>
        [Column("EVT_NUM_MAX_CANDIDATOS")]
        public int NumberMaxCandidate { get; set; }
        /// <summary>
        /// Categoría de Evento.
        /// </summary>
        /// <value></value>
        [Column("EVT_CATEGORIA")]
        public string Category { get; set; }

        /// <summary>
        /// Código de Evento
        /// </summary>
        /// <value></value>
        [Column("EVT_CODIGO_EVENTO")]
        public string CodeEvent { get; set; }

        /// <summary>
        /// Permitir libre inscripción al evento
        /// </summary>
        /// <value></value>
        [Column("EVT_LIBRE_ACCESO")]
        public bool AllowFreeAccess { get; set; }

        /// <summary>
        /// Id Usuario Creador de evento
        /// </summary>
        /// <value></value>
        [Column("EVT_ID_USUARIO_CREADOR")]
        [ForeignKey(nameof(UserCreator))]
        public int IdUser { get; set; }

        /// <summary>
        /// Fecha de Registro
        /// </summary>
        /// <value></value>
        [Column("EVT_FECHA_REGISTRO")]
        [Required]
        public DateTime DateRegister { get; set; }

        /// <summary>
        /// Fecha de Registro
        /// </summary>
        /// <value></value>
        [Column("EVT_FECHA_MAX_REGISTRO_CANDIDATOS")]
        [Required]
        public DateTime DateMaxRegisterCandidate { get; set; }

        /// <summary>
        /// Fecha de Registro
        /// </summary>
        /// <value></value>
        [Column("EVT_FECHA_MAX_REGISTRO_PARTICIPANTES")]
        [Required]
        public DateTime DateMaxRegisterParticipants { get; set; }

        /// <summary>
        /// Fecha de Registro
        /// </summary>
        /// <value></value>
        [Column("EVT_FECHA_MIN_VOTACION")]
        [Required]
        public DateTime DateMinVote { get; set; }

        /// <summary>
        /// Fecha de Registro
        /// </summary>
        /// <value></value>
        [Column("EVT_FECHA_MAX_VOTACION")]
        [Required]
        public DateTime DateMaxVote { get; set; }

        /// <summary>
        /// Evento está Activo
        /// </summary>
        /// <value></value>
        [Column("EVT_ESTADO")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Borrado Lógico del Evento
        /// </summary>
        /// <value></value>
        [Column("EVT_BORRADO")]
        public bool IsDelete { get; set; }
        #endregion

        #region Relations
        /// <summary>
        /// Eventos Usuarios
        /// </summary>
        /// <value></value>
        public ICollection<EventAdministrator> ListEventAdministrator { get; set; }

        /// <summary>
        /// Usuario creadors
        /// </summary>
        /// <value></value>
        public User UserCreator { get; set; }

        /// <summary>
        /// Eventos Usuarios
        /// </summary>
        /// <value></value>
        public ICollection<Candidate> ListCandidate { get; set; }

        /// <summary>
        /// Eventos Usuarios
        /// </summary>
        /// <value></value>
        public ICollection<Vote> ListVote { get; set; }
        #endregion


    }
}
