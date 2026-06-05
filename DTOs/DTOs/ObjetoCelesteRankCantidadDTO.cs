using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class ObjetoCelesteRankCantidadDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public int CantidadObservaciones { get; set; }
    }
}
