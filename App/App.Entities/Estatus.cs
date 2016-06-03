using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities
{
    public class Estatus
    {
        public Estatus()
        {
            Requisiciones = new List<Requisicion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Requisicion> Requisiciones { get; set; }
    }
}
