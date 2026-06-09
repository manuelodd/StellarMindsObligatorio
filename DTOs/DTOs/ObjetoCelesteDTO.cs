using StellarMinds.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class ObjetoCelesteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; }
        public decimal MagnitudAparente { get; set; }
    }
}
