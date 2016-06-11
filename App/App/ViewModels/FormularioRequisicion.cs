using App.Entities;
using System.Collections.Generic;

namespace App.ViewModels
{
    public class FormularioRequisicion
    {
        public virtual IEnumerable<Requisition> Requsiciones { get; set; }
        public virtual IEnumerable<RequisitionLine> Lineas { get; set; }
        public virtual IEnumerable<Supplier> Proveedores { get; set; }
        public virtual IEnumerable<Department> Departamentos { get; set; }
        public virtual IEnumerable<Status> Estatus { get; set; }
        public virtual IEnumerable<Period> Periodos { get; set; }
        public virtual IEnumerable<Priority> Prioridades { get; set; }
    }
}