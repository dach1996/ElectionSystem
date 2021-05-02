using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dach.ElectionSystem.Models.Persitence
{
    /// <summary>
    /// Clase de persistencia Eventos
    /// </summary>
    [Table(name: "EVENTOS_CANTIDAD")]
    public class EventNumber
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public EventNumber()
        {
            this.NumberMaxEvent=1;
        }
        #endregion

        #region Attributes

        /// <summary>
        /// Id de evento
        /// </summary>
        /// <value></value>
        [Key, Column("EVT_CAN_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Nombre evento
        /// </summary>
        /// <value></value>
        [Column("EVT_CAN_USU_ID")]
        [ForeignKey(nameof(User))]
        public int IdUser { get; set; }
        /// <summary>
        /// Dirección de foto de Evento
        /// </summary>
        /// <value></value>
        [Column("EVT_CAN_NUMERO_EVENTO")]
        public int NumberMaxEvent { get; set; }

        #endregion
        #region Relations
        /// <summary>
        /// Dirección de foto de Evento
        /// </summary>
        /// <value></value>
        public User User { get; set; }
        #endregion

    }
}
