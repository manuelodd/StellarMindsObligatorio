using StellarMinds.Enums;
using StellarMinds.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class CuerpoCeleste : IValidable
    {
        public string Nombre { get; set; }
        public TipoCuerpoCeleste Tipo {  get; set; }
        public decimal MagnitudAparente { get; set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
