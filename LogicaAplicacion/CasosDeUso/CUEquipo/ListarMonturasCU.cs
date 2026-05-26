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
    public class ListarMonturasCU : IListarMonturas
    {
        private IRepositorioEquipo repositorio;

        public ListarMonturasCU(IRepositorioEquipo repo)
        {
            repositorio = repo;
        }
        public IEnumerable<MonturaDTO> Execute()
        {
            List<MonturaDTO> montus = new List<MonturaDTO>();

            foreach (Montura montu in repositorio.FindAllMonturas())
            {
                montus.Add(MonturaDTOMapper.ToDTO(montu));
            }
            return montus;
        }
    }
}
