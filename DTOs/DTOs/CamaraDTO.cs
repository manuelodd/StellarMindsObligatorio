using StellarMinds.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class CamaraDTO
    {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int CantDisp { get; set; }
        public TipoSensor TipoSensor { get; set; }
        public int Resolution { get; set; }
        public decimal PixelSize { get; set; }
    }
}
