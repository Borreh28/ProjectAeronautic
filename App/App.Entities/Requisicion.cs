using System;
using System.Collections.Generic;

namespace App.Entities
{
    public class Requisicion
    {
        public Requisicion()
        {
            Lineas = new List<RequisicionLinea>();
        }

        public int Id { get; set; }
        public int PeriodoId { get; set; }
        public int DepartamentoId { get; set; }
        public int ProveedorId { get; set; }
        public int MonedaId { get; set; }
        public int EstatusId { get; set; }
        public int TotalLineas { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Interes { get; set; }
        public decimal GranTotal { get; set; }
        public int CreadoPor { get; set; }
        public DateTime Creado { get; set; }
        public int ActualizadoPor { get; set; }
        public DateTime Actualizado { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRequisicion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Comentarios { get; set; }
        public string PrioridadId { get; set; }

        public virtual ICollection<RequisicionLinea> Lineas { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}
