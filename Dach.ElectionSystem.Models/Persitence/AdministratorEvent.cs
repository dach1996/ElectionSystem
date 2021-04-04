using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dach.ElectionSystem.Models.Persitence
{
    /// <summary>
    /// Tabla Administradores de eventos
    /// </summary>
    [Table(name: "ADMINISTRADOR_EVENTO")]
    public class AdministratorEvent
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public AdministratorEvent()
        {
            this.Date = DateTime.Now;
            this.Privileges = "All";
            this.State = true;
        }
        /// <summary>
        /// Id Candidato
        /// </summary>
        /// <value></value>
        [Key, Column("ADMINEVENT_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Id Usuario
        /// </summary>
        /// <value></value>
        [Column("ADMINEVENT_USER_ID")]
        [ForeignKey(nameof(User))]
        public int IdUser { get; set; }
        /// <summary>
        /// Id Evento
        /// </summary>
        /// <value></value>
        [Column("ADMINEVENT_EVENT_ID")]
        [ForeignKey(nameof(Event))]
        public int IdEvent { get; set; }
        /// <summary>
        /// Fecha de registro
        /// </summary>
        /// <value></value>
        [Column("ADMINEVENT_FECHA")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Estado del Administrador
        /// </summary>
        /// <value></value>
        [Column("ADMINEVENT_ESTADO")]
        public bool State { get; set; }
        
        /// <summary>
        /// Privilegios
        /// </summary>
        /// <value></value>
        [Column("ADMINEVENT_PRVILEGIOS")]
        public string Privileges { get; set; }
       
        /// <summary>
        /// Evento
        /// </summary>
        /// <value></value>
        public Event Event { get; set; }
        /// <summary>
        /// Usuarios
        /// </summary>
        /// <value></value>
        public User  User { get; set; }

        
    }
}