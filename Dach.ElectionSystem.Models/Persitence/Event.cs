using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dach.ElectionSystem.Models.Persitence
{
    [Table(name: "EVENTOS")]
    public class Event
    {
        [Key,Column("ID_EVENTO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("NOMBRE_EVENTO")]
        public string Name { get; set; }
        [Column("FOTO_EVENTO")]
        public string Image { get; set; }
        [Column("DESCRIPCION_EVENTO")]
        public string Description { get; set; }
        [Column("MAX_PERSONAS_EVENTO")]
        public bool MaxPeople { get; set; }
        [Column("NUM_MAX_PERSONAS_EVENTO")]
        public int NumberMaxPeople { get; set; }
        [Column("NUM_MAX_CANDIDATOS_EVENTO")]
        public int NumberMaxCandidate { get; set; }
        [Column("CATEGORIA")]
        public string Category { get; set; }

    }
}
