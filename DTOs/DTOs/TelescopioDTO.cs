using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class TelescopioDTO : EquipoDTO
    {
        /*
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int CantDisp { get; set; }
        */
        public decimal Apertura { get; set; }
        public string RelacionFocal { get; set; } = string.Empty;
        public decimal DistanciaFocal { get; set; }
        public decimal PesoKG { get; set; }
    }
}
