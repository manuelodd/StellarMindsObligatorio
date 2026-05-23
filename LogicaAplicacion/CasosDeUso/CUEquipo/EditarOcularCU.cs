using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUEquipo
{
    public class EditarOcularCU : IEditarOcular
    {
        private IRepositorioEquipo repo;

        public EditarOcularCU(IRepositorioEquipo repo)
        {
            this.repo = repo;
        }
        public void Execute(OcularDTO dto)
        {
            repo.EditOcular(OcularDTOMapper.FromDTO(dto));
        }
    }
}
