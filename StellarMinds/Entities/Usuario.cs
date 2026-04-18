using Dominio.ValueObjects;
using StellarMinds.Enums;
using StellarMinds.InterfacesDominio;
using StellarMinds.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Exceptions;

namespace StellarMinds.Entities
{
    public class Usuario : IValidable
    {

        private static int _id = 0;
        public int Id { get; set; }
        public UsuarioNombreCompleto NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RolUsuario Rol { get; set; }
        public UsuarioDireccion Direccion { get; set; }



        public Usuario(string nombre, string apellido, string telefono, string email, string username, string password, RolUsuario rol, string pais, string ciudad, string calle)
        {
            Id = _id++;
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
            // ToDo, solo para poner algo y poner debuggear
            if (string.IsNullOrEmpty(Email))
                throw new InvalidUser("Email no puede ser vacío");
        }
    }


}
