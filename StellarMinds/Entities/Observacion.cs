using StellarMinds.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class Observacion : IValidable
    {
        private static int _id = 0;
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public Observacion()
        {
            Id = _id++;
        }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
