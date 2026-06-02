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
        public int SocioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public EstadoPrestamo Estado { get; set; }
        public int TelescopioID { get; set; }
        public int MonturaID { get; set; } 
        public int? CamaraID { get; set; }
        public int? OcularID { get; set; }

    }
}