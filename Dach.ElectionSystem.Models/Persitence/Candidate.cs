
using System.ComponentModel.DataAnnotations.Schema;

namespace Dach.ElectionSystem.Models.Persitence
{
    [Table(name: "CANDIDATOS")]
    public class Candidate
    {
        [Column("ID_CANDIDATOS")]
        public int Id { get; set; }
        [Column("IMAGEN_CANDIDATO")]
        public string Image { get; set; }
        [Column("VIDEO_CANDIDATO")]
        public string Video { get; set; }
        [Column("DETALLES_CANDIDATO")]
        public string Details { get; set; }
        [Column("ROL_CANDIDATO")]
        public string Role { get; set; }
        [Column("EDAD_CANDIDATO")]
        public int Age { get; set; }
        [Column("PROPUESTA_CANDIDATO")]
        public string ProposalDetails { get; set; }
        [Column("PUESTOS_LABORALES_CANDIDATO")]
        public string PostionsWorks { get; set; }
    }
}