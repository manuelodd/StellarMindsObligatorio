using StellarMinds.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class Montura : Equipo
    {
        public TipoMontura Tipo { get; set; }
        public decimal CargaKG { get; set; }
        public bool GoTo { get; set; }
    }
}
