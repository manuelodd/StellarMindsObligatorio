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
    public class ListarTelescopiosCU : IListarTelescopios
    {
        private IRepositorioEquipo repositorio;

        public ListarTelescopiosCU(IRepositorioEquipo repo)
        {
            repositorio = repo;
        }
        public IEnumerable<TelescopioDTO> Execute()
        {
            List<TelescopioDTO> teles = new List<TelescopioDTO>();

            foreach (Telescopio tele in repositorio.FindAllTelescopios())
            {
                teles.Add(TelescopioDTOMapper.ToDTO(tele));
            }
            return teles;
        }
    }
}
