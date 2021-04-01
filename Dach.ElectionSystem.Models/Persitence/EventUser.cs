using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dach.ElectionSystem.Models.Persitence
{
    /// <summary>
    /// Clase de persistencia muchos a muchos Eventos Usuarios
    /// </summary>
    [Table(name: "EVENTOS_USUARIOS")]
    public class EventUser
    {
        /// <summary>
        /// Id de Eventos Usuario
        /// </summary>
        /// <value></value>
        [Key, Column("ID_EVENTOS_USUARIOS")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Id Usuario
        /// </summary>
        /// <value></value>
        [Column("ID_USUARIO_EU")]
        [ForeignKey(nameof(User))]
        public int IdUser { get; set; }
        /// <summary>
        /// Id Evento
        /// </summary>
        /// <value></value>
        [Column("ID_EVENTO_EU")]
        [ForeignKey(nameof(Event))]
        public int IdEvent { get; set; }
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