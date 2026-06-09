using Dominio;
using DTOs.DTOs;
using StellarMinds.Entities;
using StellarMinds.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class UsuarioDTOMapper
    {
        public static UsuarioDTO ToDTO(Usuario unUsuario)
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
                Rol = unUsuario.Rol.ToString(),
                Pais = unUsuario.Direccion.Pais,
                Ciudad = unUsuario.Direccion.Ciudad,
                Calle = unUsuario.Direccion.Calle
            };
        }

        public static Usuario FromDTO(UsuarioDTO dto)
        {
            return new Usuario
            {
                Id = dto.Id,
                NombreCompleto = new Dominio.ValueObjects.UsuarioNombreCompleto(dto.Nombre, dto.Apellido),
                Telefono = dto.Telefono,
                Email = dto.Email,
                Username = dto.Username,
                Password = dto.Password,
                Rol = Enum.Parse<RolUsuario>(dto.Rol),
                Direccion = new Dominio.ValueObjects.UsuarioDireccion(dto.Pais, dto.Ciudad, dto.Calle)
            };
        }
    }
}
