using Dominio.Entities;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class ObservacionDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int PrestamoId { get; set; }
        public int ObjetoCelesteId { get; set; }
        public string Indicador { get; set; } = string.Empty;
        public string Detalle { get; set; } = string.Empty;
    }
}
