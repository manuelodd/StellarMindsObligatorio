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
    public class FindUsuByIdCU : IFindUsuById
    {
        private IRepositorioUsuario repositorio;
        public FindUsuByIdCU(IRepositorioUsuario repo)
        {
            repositorio = repo;
        }
        public UsuarioDTO Execute(int id)
        {
            Usuario usuario = repositorio.FindById(id);
            return UsuarioDTOMapper.ToDTO(usuario);
        }
    }
}
