using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUEquipo
{
    public class ListarTelescopiosToListCU : IListarTelescopiosToList
    {
            
        private IRepositorioEquipo repositorio;

        public ListarTelescopiosToListCU(IRepositorioEquipo repo)
        {
            repositorio = repo;
        }
        public IEnumerable<TelescopioDTO> Execute()
        {
            List<TelescopioDTO> lista = new List<TelescopioDTO>();

            foreach (Telescopio teles in repositorio.FindAllTelescopiosToList())
            {
                lista.Add(TelescopioDTOMapper.ToDTO(teles));
            }
            return lista;
        }
    }
}
