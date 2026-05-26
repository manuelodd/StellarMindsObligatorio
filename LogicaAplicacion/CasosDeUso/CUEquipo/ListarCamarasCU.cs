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
    public class ListarCamarasCU : IListarCamaras
    {
        private IRepositorioEquipo repositorio;

        public ListarCamarasCU(IRepositorioEquipo repo)
        {
            repositorio = repo;
        }
        public IEnumerable<CamaraDTO> Execute()
        {
            List<CamaraDTO> camas = new List<CamaraDTO>();

            foreach (Camara cama in repositorio.FindAllCamaras())
            {
                camas.Add(CamaraDTOMapper.ToDTO(cama));
            }
            return camas;
        }
    }
}
