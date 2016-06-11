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
            Requisiciones = new List<Requisition>();
        }

        public string Id { get; set; }

        public virtual ICollection<Requisition> Requisiciones { get; set; }
    }
}
