using System.Collections.Generic;

namespace App.Entities
{
    public class Status
    {
        public Status()
        {
            Requisitions = new List<Requisition>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Requisition> Requisitions { get; set; }
    }
}
