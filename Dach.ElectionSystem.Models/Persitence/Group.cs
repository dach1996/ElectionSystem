using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Persitences
{
    [Table(name: "GRUPOS")]
    public class Group
    {
        [Column("ID_GRUPO")]
        public int Id { get; set; }

        [Column("NOMBRE_GRUPO")]
        public string Name { get; set; }

        [Column("DETALLES_GRUPO")]
        public string Details { get; set; }

        [Column("MAXIMO_CANDIDATOS_GRUPO")]
        public int MaxCandidate { get; set; }

        [Column("FOTO_GRUPO")]
        public string  Image { get; set; }
    }
}
