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
    public class BuscarEquipoPorIDCU : IBuscarEquipoPorID
    {
        private IRepositorioEquipo repositorio;

        public BuscarEquipoPorIDCU(IRepositorioEquipo repo)
        {
            repositorio = repo;
        }
        public EquipoDTO Execute(int id)
        {
            Equipo equipo = repositorio.FindById(id);
            return EquipoDTOMapper.ToDTO(equipo);
        }
    }
}
