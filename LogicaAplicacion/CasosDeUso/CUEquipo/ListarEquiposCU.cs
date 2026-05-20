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
    public class ListarEquiposCU : IListarEquipos
    {
        private IRepositorioEquipo repositorio;

        public ListarEquiposCU(IRepositorioEquipo repo)
        {
            repositorio = repo;
        }
        public List<EquipoDTO> Execute()
        {
            List<EquipoDTO> equipos = new List<EquipoDTO>();

            foreach(Equipo equipo in repositorio.FindAll())
            {
                equipos.Add(EquipoDTOMapper.ToListDTO(equipo));
            }
            return equipos;
        }

    }
}
