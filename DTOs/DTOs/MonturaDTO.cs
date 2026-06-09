using StellarMinds.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class MonturaDTO : EquipoDTO
    {
        /*
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int CantDisp { get; set; }
        */
        public string Tipo { get; set; }
        public decimal CargaKG { get; set; }
        public bool GoTo { get; set; }
    }
}
