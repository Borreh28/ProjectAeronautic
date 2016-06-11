using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities
{
    public class Periodo
    {
        public Periodo()
        {
            Requisiciones = new List<Requisition>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Requisition> Requisiciones { get; set; }
    }
}
