using StellarMinds.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Dominio.ValueObjects
{
    [Owned]
    public class UsuarioNombreCompleto : IValidable 
    
    {
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }

        public UsuarioNombreCompleto(string nombre, string apellido) 
        {
            Nombre = nombre;
            Apellido = apellido;
        }
        public void Validar() 
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new InvalidFullName("Nombre no puede ser vacío");
            if (string.IsNullOrEmpty(Apellido))
                throw new InvalidFullName("Apellido no puede ser vacío");
        }
    }
}
