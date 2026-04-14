using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class Montura
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CantidadDisp {  get; set; }
        public Enum Tipo { get; set; }
        public decimal CargaKG { get; set; }
        public bool EsComputarizado { get; set; }
    }
}
