using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class Camara
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CantidadDisp {  get; set; }
        public Enum TipoSensor { get; set; }



        public int Resolucion { get; set; }
        public decimal PixelSize { get; set; }
    }
}
