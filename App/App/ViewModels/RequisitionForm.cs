using App.Entities;
using System.Collections.Generic;

namespace App.ViewModels
{
    public class RequisitionForm
    {
        public virtual IEnumerable<Department> Departments { get; set; }
        public virtual IEnumerable<Period> Periods { get; set; }
        public virtual IEnumerable<Priority> Priorities { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
        public virtual IEnumerable<Requisition> Requisitions { get; set; }
        public virtual IEnumerable<RequisitionLine> Lines { get; set; }
        public virtual IEnumerable<Status> Status { get; set; }
        public virtual IEnumerable<Supplier> Suppliers { get; set; }
    }
}