using System;
using System.Collections.Generic;

namespace App.Entities
{
    public class Supplier
    {
        public Supplier()
        {
            Requisitions = new List<Requisition>();
        }

        public int Id { get; set; }

        public bool Active { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime Updated { get; set; }

        public virtual ICollection<Requisition> Requisitions { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
