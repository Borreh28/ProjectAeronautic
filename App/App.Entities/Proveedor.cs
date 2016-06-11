using System;
using System.Collections.Generic;

namespace App.Entities
{
    public class Proveedor
    {
        public Proveedor()
        {
            Requisiciones = new List<Requisition>();
        }

        public int Id { get; set; }
        public bool Activo { get; set; }
        public string Nombre { get; set; }
        public int CreadoPor { get; set; }
        public DateTime Creado { get; set; }
        public int ActualizadoPor { get; set; }
        public DateTime Actualizado { get; set; }

        public virtual ICollection<Requisition> Requisiciones { get; set; }
    }
}
