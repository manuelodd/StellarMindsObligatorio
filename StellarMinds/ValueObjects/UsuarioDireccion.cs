using Dominio.Exceptions;
using StellarMinds.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.ValueObjects
{
    public class UsuarioDireccion : IValidable
    {

        public string Pais {  get; private set; }
        public string Ciudad { get; private set; }
        public string Calle { get; private set; }

        public UsuarioDireccion(string pais, string ciudad, string calle)
            {
            Pais = pais;
            Ciudad = ciudad;
            Calle = calle;
            }
        public void Validar() 
            {
            if (string.IsNullOrEmpty(Pais))
                throw new InvalidDirection("País no puede ser vacío");
            if (string.IsNullOrEmpty(Ciudad))
                throw new InvalidDirection("Ciudad no puede ser vacía");
            if (string.IsNullOrEmpty(Calle))
                throw new InvalidDirection("Calle no puede ser vacía");
        }
    }
}
