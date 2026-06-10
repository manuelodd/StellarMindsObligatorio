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
    public class ListarSociosCU : IListarSocios
    {
        private IRepositorioUsuario repositorio;

        public ListarSociosCU(IRepositorioUsuario repo)
        {
            repositorio = repo;
        }

        public IEnumerable<UsuarioDTO> Execute()
        {
            List<UsuarioDTO> listado = new List<UsuarioDTO>();

            foreach(Usuario usu in repositorio.FindAllSocios())
            {
                listado.Add(UsuarioDTOMapper.ToDTO(usu));
            }
            return listado;
        }
    }
}
