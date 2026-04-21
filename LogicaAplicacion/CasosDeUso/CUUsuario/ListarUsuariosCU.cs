using Dominio.InterfacesRepositorio;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaAccesoDatos.RepositorioMemoria;
using System;
using System.Collections.Generic;
using System.Text;
using StellarMinds.Entities;
using System.Runtime.Versioning;
using DTOs.DTOs;
using DTOs.Mappers;

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
                aRetornar.Add(UsuarioDTOMapper.ToDto(unUsuario));
            }
            return aRetornar;
        }
        /*
        public IEnumerable<Usuario> FindAll()
        {
            return _usuarios;
        }
        */
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