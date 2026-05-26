using StellarMinds.Entities;
using StellarMinds.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class PrestamoDTO
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public EstadoPrestamo Estado { get; set; }
        public int? TelescopioID { get; set; } = null;
        public int? MonturaID { get; set; } = null;
        public int? CamaraID { get; set; } = null;
        public int? OcularID { get; set; } = null;

    }
}