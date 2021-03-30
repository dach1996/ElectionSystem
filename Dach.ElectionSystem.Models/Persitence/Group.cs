using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Persitences
{
    /// <summary>
    /// Clase modelo para Persistencia de Grupos
    /// </summary>
    [Table(name: "GRUPOS")]
    public class Group
    {
        /// <summary>
        /// Id de Grupo
        /// </summary>
        /// <value></value>
        [Key,Column("ID_GRUPO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Nombre de Grupo
        /// </summary>
        /// <value></value>
        [Column("NOMBRE_GRUPO")]
        public string Name { get; set; }
        /// <summary>
        /// Detalles de grupo
        /// </summary>
        /// <value></value>
        [Column("DETALLES_GRUPO")]
        public string Details { get; set; }
        /// <summary>
        /// Máximo de candidatos por grupo
        /// </summary>
        /// <value></value>
        [Column("MAXIMO_CANDIDATOS_GRUPO")]
        public int MaxCandidate { get; set; }
        /// <summary>
        /// Ruta de imágen para grupo
        /// </summary>
        /// <value></value>
        [Column("FOTO_GRUPO")]
        public string  Image { get; set; }
        /// <summary>
        /// Estado de Grupo
        /// </summary>
        [Column("ESTADO_GRUPO")]
         public bool IsActive { get; set; }
    }
}
