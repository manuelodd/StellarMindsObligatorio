using Dominio.ValueObjects;
using StellarMinds.Enums;
using StellarMinds.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Exceptions;
using System.Reflection;

namespace StellarMinds.Entities
{
    public class Usuario : IValidable
    {
        public int Id { get; set; }
        public UsuarioNombreCompleto NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RolUsuario Rol { get; set; }
        public UsuarioDireccion Direccion { get; set; }

        public Usuario() { }

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
            // ToDo, solo para poner algo y poner debuggear
            if (string.IsNullOrEmpty(NombreCompleto.Nombre))
                throw new InvalidUserException("Nombre no puede ser vacío.");
            if (string.IsNullOrEmpty(NombreCompleto.Apellido))
                throw new InvalidUserException("Apellido no puede ser vacío.");
            if (string.IsNullOrEmpty(Telefono))
                throw new InvalidUserException("Teléfono no puede ser vacío.");
            if (string.IsNullOrEmpty(Email))
                throw new InvalidUserException("Email no puede ser vacío.");
            if (string.IsNullOrEmpty(Username))
                throw new InvalidUserException("Username no puede ser vacío.");
            if (string.IsNullOrEmpty(Password))
                throw new InvalidUserException("Password no puede ser vacío.");
            if (string.IsNullOrEmpty(Direccion.Pais))
                throw new InvalidUserException("Pais no puede ser vacío.");
            if (string.IsNullOrEmpty(Direccion.Ciudad))
                throw new InvalidUserException("Ciudad no puede ser vacía.");
            if (string.IsNullOrEmpty(Direccion.Calle))
                throw new InvalidUserException("Calle no puede ser vacía.");
            if (Password.Length < 8)
                throw new InvalidUserException("La contraseña debe tener al menos 8 caracteres.");
            
            bool mayus = false;
            bool minus = false;
            bool numb = false;
            bool simb = false;

            foreach (char c in Password){
                if  (char.IsUpper(c))           mayus = true;
                else if (char.IsLower(c))       minus = true;
                else if (char.IsDigit(c))       numb = true;
                else                            simb = true;
            }

            if (!mayus)
                throw new InvalidUserException("La contraseña debe tener al menos una mayúscula.");
            if (!minus)
                throw new InvalidUserException("La contraseña debe tener al menos una minúscula.");
            if (!numb)
                throw new InvalidUserException("La contraseña debe tener al menos un número.");
            if (!simb)
                throw new InvalidUserException("La contraseña debe tener al menos un carácter especial.");
        }
    }


}
