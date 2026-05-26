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
    public class ListarOcularesCU : IListarOculares
    {
        private IRepositorioEquipo repositorio;

        public ListarOcularesCU(IRepositorioEquipo repo)
        {
            repositorio = repo;
        }
        public IEnumerable<OcularDTO> Execute()
        {
            List<OcularDTO> ocus = new List<OcularDTO>();

            foreach (Ocular ocu in repositorio.FindAllOculares())
            {
                ocus.Add(OcularDTOMapper.ToDTO(ocu));
            }
            return ocus;
        }
    }
}
