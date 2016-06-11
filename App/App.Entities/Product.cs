using System;
using System.Collections.Generic;

namespace App.Entities
{
    public class Product
    {
        public Product()
        {
            Lines = new List<RequisitionLine>();
        }

        public int Id { get; set; }

        public int SupplierId { get; set; }
        public int CategoryId { get; set; }

        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal BudgetPrice { get; set; }
        public int UnitPerPack { get; set; }
        public string UM { get; set; }
        public int UnitInStock { get; set; }
        public int UnitOnOrder { get; set; }
        public int ReOrderLevel { get; set; }
        public bool Discontinued { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public int UpdateBy { get; set; }
        public DateTime Updated { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<RequisitionLine> Lines { get; set; }
    }
}
