using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Persitence
{
    [Table(name:"USUARIOS")]
    public class User
    {
        [Key,Column("ID_USUARIO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("NOMBRE_USUARIO")]
        public string UserName { get; set; }
        [Column("PASSWORD_USUARIO")]
        public string  Password { get; set; }
    }
}
