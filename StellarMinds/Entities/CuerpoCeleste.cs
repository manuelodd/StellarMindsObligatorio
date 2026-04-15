using StellarMinds.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class CuerpoCeleste
    {
        public string Nombre { get; set; }
        public TipoCuerpoCeleste Tipo {  get; set; }
        public decimal MagnitudAparente { get; set; }

    }
}
