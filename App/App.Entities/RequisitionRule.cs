﻿using System;
using System.Collections.Generic;

namespace App.Entities
{
    public class RequisitionRule
    {
        public RequisitionRule()
        {
            Requisitions = new List<Requisition>();
        }

        public int Id { get; set; }

        public int RequisitionId { get; set; }

        public string AuthorizationState { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime Updated { get; set; }

        public virtual ICollection<Requisition> Requisitions { get; set; }
    }
}