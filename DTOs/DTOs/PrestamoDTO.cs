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
        public int? Telescopio { get; set; } = null;
        public int? Montura { get; set; } = null;
        public int? Camara { get; set; } = null;
        public int? Ocular { get; set; } = null;

    }
}