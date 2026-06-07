using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
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

            public Usuario Execute(string username, string password)
            {
                Usuario usuario = repositorio.FindByUsername(username);

                if (usuario == null)
                    throw new InvalidUserException("Usuario no existe.");

                if (usuario.Password != password)
                    throw new InvalidUserException("Contraseña incorrecta.");

                return usuario;
            }
        
    }
}
