using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class Telescopio : Equipo
    {

        public decimal Apertura { get; set; }
        public string RelacionFocal { get; set; }
        public decimal DistanciaFocal { get; set; }
        public decimal PesoKG { get; set; }
    }
}
