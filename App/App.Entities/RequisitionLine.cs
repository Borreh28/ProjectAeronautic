using System;

namespace App.Entities
{
    public class RequisitionLine
    {
        public int Id { get; set; }

        public int RequisitionId { get; set; }
        public int ProductId { get; set; }

        public int Line { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime Updated { get; set; }

        public virtual Requisition Requisition { get; set; }
        public virtual Product Product { get; set; }
    }
}
