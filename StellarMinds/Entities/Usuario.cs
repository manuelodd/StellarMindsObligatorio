using Dominio.ValueObjects;
using StellarMinds.Enums;
using StellarMinds.InterfacesDominio;
using StellarMinds.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class Usuario : IValidable
    {

        public UsuarioNombreCompleto NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RolUsuario Rol { get; set; }
        public UsuarioDireccion Direccion { get; set; }



        public Usuario(string nombre, string apellido, string telefono, string email, string username, string password, RolUsuario rol, string pais, string ciudad, string calle)
        {
            NombreCompleto = new UsuarioNombreCompleto(nombre, apellido);
            Telefono = telefono;
            Email = email;
            Username = username;
            Password = password;
            Rol = rol;
            Direccion = new UsuarioDireccion(pais, ciudad, calle);
        }

        public void Validar()
        {
            //ToDo
        }
    }


}
