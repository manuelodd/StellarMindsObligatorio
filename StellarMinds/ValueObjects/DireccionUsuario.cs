using StellarMinds.Exceptions;
using StellarMinds.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.ValueObjects
{
    public class DireccionUsuario : IValidable
    {

        public string Pais {  get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }

        public DireccionUsuario(string pais, string ciudad, string calle)
            {
            Pais = pais;
            Ciudad = ciudad;
            Calle = calle;
            }
        public void Validar() 
            {
            if (string.IsNullOrEmpty(Pais))
                throw new InvalidDirectionException("País no puede ser vacío");
            if (string.IsNullOrEmpty(Ciudad))
                throw new InvalidDirectionException("Ciudad no puede ser vacía");
            if (string.IsNullOrEmpty(Calle))
                throw new InvalidDirectionException("Calle no puede ser vacía");
        }
    }
}
