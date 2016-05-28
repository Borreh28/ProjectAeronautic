using System;
using System.Collections.Generic;

namespace App.Entities
{
    public class Departamento
    {
        public Departamento()
        {
            Requisiciones = new List<Requisicion>();
        }

        public int Id { get; set; }
        public int EdificioId { get; set; }
        public bool Activo { get; set; }
        public string Nombre { get; set; }
        public int CreadoPor { get; set; }
        public DateTime Creado { get; set; }
        public int ActualizadoPor { get; set; }
        public DateTime Actualizado { get; set; }

        public virtual ICollection<Requisicion> Requisiciones { get; set; }
    }
}
