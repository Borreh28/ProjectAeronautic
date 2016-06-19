using System;
using System.Collections.Generic;

namespace App.Entities
{
    public class Requisition
    {
        public Requisition()
        {
            Lines = new List<RequisitionLine>();
        }

        public int Id { get; set; }

        public int PeriodId { get; set; }
        public int DepartmentId { get; set; }
        public int SupplierId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }

        public bool Active { get; set; }
        public int TotalLines { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Interest { get; set; }
        public decimal Total { get; set; }
        public DateTime RequisitionDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Description { get; set; }
        public string Commentaries { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime Updated { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual Department Department { get; set; }
        public virtual Period Period { get; set; }
        public virtual Status Status { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual ICollection<RequisitionLine> Lines { get; set; }
        public virtual ICollection<RequisitionRule> Rules { get; set; }
    }
}
