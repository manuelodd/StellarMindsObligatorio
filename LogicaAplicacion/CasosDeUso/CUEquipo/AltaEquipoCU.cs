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
        public void Execute(EquipoDTO dto)
        {
            Equipo equipo = null;

            if (dto is TelescopioDTO teleDto)
            {
                equipo = EquipoDTOMapper.FromDTOTele(teleDto);
            }
            else if (dto is MonturaDTO montuDto)
            {
                equipo = EquipoDTOMapper.FromDTOMontu(montuDto);
            }
            else if (dto is CamaraDTO camaDto)
            {
                equipo = EquipoDTOMapper.FromDTOCama(camaDto);
            }
            else if (dto is OcularDTO ocuDto)
            {
                equipo = EquipoDTOMapper.FromDTOOcu(ocuDto);
            }

            repositorio.Alta(equipo);
        }

    }
}
