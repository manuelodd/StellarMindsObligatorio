using StellarMinds.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class Observacion : IValidable
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public Observacion()
        {

        }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
