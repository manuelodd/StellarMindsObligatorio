using Dominio.Exceptions;
using StellarMinds.Enums;
using StellarMinds.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class ObjetoCeleste : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public TipoObjetoCeleste? Tipo {  get; set; }
        public decimal MagnitudAparente { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new InvalidObjetoCeleste("El nombre no puede ser vacío.");
            if (Tipo == null)
                throw new InvalidObjetoCeleste("Tiene que elegir un tipo.");
        }
    }
}
