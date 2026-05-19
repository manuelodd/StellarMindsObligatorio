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
    public class AltaEquipoCU : IAltaEquipo
    {
        private IRepositorioEquipo repositorio;

        public AltaEquipoCU(IRepositorioEquipo repo)
        {
            repositorio = repo;
        }
        public void Execute(Equipo unEquipo)
        {
            repositorio.Alta(unEquipo);

        }

    }
}
