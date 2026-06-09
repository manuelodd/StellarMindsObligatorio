using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUUsuario
{
    public class LoginUsuarioCU : ILoginUsuario
    {

            private IRepositorioUsuario repositorio;

            public LoginUsuarioCU(IRepositorioUsuario repo)
            {
                this.repositorio = repo;
            }

            public UsuarioDTO Execute(string username, string password)
            {
                return UsuarioDTOMapper.ToDTO(repositorio.Login(username, password));
            }
        
    }
}
