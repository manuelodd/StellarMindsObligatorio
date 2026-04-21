using DTOs.DTOs;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class UsuarioDTOMapper
    {
        public static UsuarioDTO ToDto(Usuario unUsuario)
        {
            return new UsuarioDTO
            {
                Id = unUsuario.Id,
                Nombre = unUsuario.NombreCompleto.Nombre,
                Apellido = unUsuario.NombreCompleto.Apellido,
                Telefono = unUsuario.Telefono,
                Email = unUsuario.Email,
                Username = unUsuario.Username,
                Password = unUsuario.Password,
                Rol = unUsuario.Rol,
                Pais = unUsuario.Direccion.Pais,
                Ciudad = unUsuario.Direccion.Ciudad,
                Calle = unUsuario.Direccion.Calle
            };
        }
    }
}
