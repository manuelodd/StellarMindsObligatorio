using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class Telescopio
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CantidadDisp {  get; set; }
        public int Apertura { get; set; }
        public string RelacionFocal { get; set; }
        public int DistanciaFocal { get; set; }
        public decimal PesoKG { get; set; }
    }
}
