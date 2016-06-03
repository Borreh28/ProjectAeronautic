using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities
{
    public class Prioridad
    {
        public Prioridad()
        {
            Requisiciones = new List<Requisicion>();
        }

        public string Id { get; set; }

        public virtual ICollection<Requisicion> Requisiciones { get; set; }
    }
}
