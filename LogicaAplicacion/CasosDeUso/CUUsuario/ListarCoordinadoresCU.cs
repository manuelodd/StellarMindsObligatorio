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
    public class ListarCoordinadoresCU : IListarCoordinadores
    {
        private IRepositorioUsuario repositorio;
        public ListarCoordinadoresCU(IRepositorioUsuario repo)
        {
            repositorio = repo;
        }
        public List<UsuarioDTO> Execute()
        {
            List<UsuarioDTO> listado = new List<UsuarioDTO>();

            foreach(Usuario usu in repositorio.FindCoordinadores())
            {
                listado.Add(UsuarioDTOMapper.ToDTO(usu));
            }
            return listado;
        }
    }
}
