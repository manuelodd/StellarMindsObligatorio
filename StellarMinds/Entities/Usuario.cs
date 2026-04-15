using StellarMinds.InterfacesDominio;
using StellarMinds.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class Usuario : IValidable
    {

        public string NombreCompleto { get; set; }
        public DireccionUsuario Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RolUsuario Rol { get; set; }


        public void Validar()
        {

        }
    }


}
