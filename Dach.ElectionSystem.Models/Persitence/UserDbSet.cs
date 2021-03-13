using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Persitence
{
    public class UserDbSet
    {
        public int Id { get; set; }
        public string usuario { get; set; }

        public string  password { get; set; }
    }
}
