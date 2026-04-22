using StellarMinds.Enums;
using StellarMinds.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class Camara : Equipo
    {

        public TipoSensor TipoSensor { get; set; }
        public int Resolution { get; set; }
        public decimal PixelSize { get; set; }

        
    }
}
