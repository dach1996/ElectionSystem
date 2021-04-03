using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dach.ElectionSystem.Models.Persitence
{
    /// <summary>
    /// Clase modelo para Persistencia de Grupos
    /// </summary>
    [Table(name: "GRUPOS")]
    public class Group
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <returns></returns>
        public Group()
        {
            this.Event = new Event();
            this.IsActive = true;
        }
        #endregion

        #region Attributes
        /// <summary>
        /// Id de Grupo
        /// </summary>
        /// <value></value>
        [Key, Column("GRP_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Nombre de Grupo
        /// </summary>
        /// <value></value>
        [Column("GRP_NOMBRE")]
        public string Name { get; set; }

        /// <summary>
        /// Detalles de grupo
        /// </summary>
        /// <value></value>
        [Column("GRP_DETALLES")]
        public string Details { get; set; }

        /// <summary>
        /// Máximo de candidatos por grupo
        /// </summary>
        /// <value></value>
        [Column("GRP_MAXIMO_CANDIDATOS")]
        public int MaxCandidate { get; set; }

        /// <summary>
        /// Ruta de imágen para grupo
        /// </summary>
        /// <value></value>
        [Column("GRP_FOTO")]
        public string Image { get; set; }

        /// <summary>
        /// Estado de Grupo
        /// </summary>
        [Column("GRP_ESTADO")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Id de evento
        /// </summary>
        [Column("GRP_EVENTO_ID")]
        [ForeignKey(nameof(Event))]
        public int IdEvent { get; set; }
        #endregion

        #region Attributes
        /// <summary>
        /// Evento
        /// </summary>
        /// <value></value>
        public Event Event { get; set; }
        #endregion
    }
}
