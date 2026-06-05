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
    public class ListarSociosByTelescopioCU : IListarSociosByTelescopio
    {
        private IRepositorioUsuario repositorio;

        public ListarSociosByTelescopioCU(IRepositorioUsuario repo)
        {
            repositorio = repo;
        }
        public IEnumerable<UsuarioDTO> Execute(int telescopioId)
        {
            List<UsuarioDTO> lista = new List<UsuarioDTO>();
            foreach(Usuario usu in repositorio.FindSociosPorTelescopio(telescopioId))
            {
                lista.Add(UsuarioDTOMapper.ToDTO(usu));
            }
            return lista;
        }
    }
}
