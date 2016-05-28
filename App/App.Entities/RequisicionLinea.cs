using System;
using System.Collections.Generic;

namespace App.Entities
{
    public class RequisicionLinea
    {
        public string Id { get; set; }
        public int RequisicionId { get; set; }
        public int Linea { get; set; }
        public int ParteId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public string Descripcion { get; set; }
        public int CreadoPor { get; set; }
        public DateTime Creado { get; set; }
        public int ActualizadoPor { get; set; }
        public DateTime Actualizado { get; set; }

        public virtual Requisicion Requisicion { get; set; }
    }
}
