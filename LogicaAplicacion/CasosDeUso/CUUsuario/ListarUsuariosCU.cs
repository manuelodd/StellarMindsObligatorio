using Dominio.InterfacesRepositorio;
using DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaAccesoDatos.RepositorioMemoria;
using System;
using System.Collections.Generic;
using System.Text;
using StellarMinds.Entities;
using System.Runtime.Versioning;

namespace LogicaAplicacion.CasosDeUso.CUUsuario
{
    public class ListarUsuariosCU : IListarUsuarios
    {

        private IRepositorioUsuario repositorio;

        public ListarUsuariosCU(IRepositorioUsuario repo)
        {
            repositorio = repo;
        }

        public List<UsuarioDTO> ListarUsuarios()
        {
            List<UsuarioDTO> aRetornar = new List<UsuarioDTO>();
            foreach(Usuario unUsuario in repositorio.FindAll())
            {
                UsuarioDTO dto = new UsuarioDTO();
                dto.Nombre = unUsuario.NombreCompleto.Nombre;
                dto.Apellido = unUsuario.NombreCompleto.Apellido;
                dto.Telefono = unUsuario.Telefono;
                dto.Email = unUsuario.Email;
                dto.Username = unUsuario.Username;
                dto.Password = unUsuario.Password;
                dto.Rol = unUsuario.Rol;
                aRetornar.Add(dto);
            }
            return aRetornar;
        }
    }
}
/*
             unUsuario.Id = dto.Id;
            unUsuario.NombreCompleto = new UsuarioNombreCompleto(dto.Nombre, dto.Apellido);
            unUsuario.Telefono = dto.Telefono;
            unUsuario.Email = dto.Email;
            unUsuario.Username = dto.Username;
            unUsuario.Password = dto.Password;
            unUsuario.Rol = dto.Rol;*/