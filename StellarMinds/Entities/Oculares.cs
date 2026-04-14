using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class OCulares
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CantidadDisp {  get; set; }
        public decimal Diametro { get; set; }
        public decimal GradosVision { get; set; }
    }
}
