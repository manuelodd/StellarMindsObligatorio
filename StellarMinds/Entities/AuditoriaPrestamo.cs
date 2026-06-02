using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class AuditoriaPrestamo
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; } = string.Empty;
        public int PrestamoId { get; set; }
        public int CoordinadorId { get; set; }
        public Prestamo Prestamo { get; set; }
        public Usuario Coordinador { get; set; }
    }
}
