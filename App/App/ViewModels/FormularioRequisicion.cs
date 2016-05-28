using App.Entities;
using System.Collections.Generic;

namespace App.ViewModels
{
    public class FormularioRequisicion
    {
        public virtual IEnumerable<Requisicion> Requsiciones { get; set; }
        public virtual IEnumerable<RequisicionLinea> Lineas { get; set; }
        public virtual IEnumerable<Proveedor> Proveedores { get; set; }
        public virtual IEnumerable<Departamento> Departamentos { get; set; }
    }
}