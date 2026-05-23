using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUEquipo
{
    public class EditarTelescopioCU : IEditarTelescopio
    {

        private IRepositorioEquipo repo;

        public EditarTelescopioCU(IRepositorioEquipo repo)
        {
            this.repo = repo;
        }
        public void Execute(TelescopioDTO dto)
        {
            repo.EditTelescopio(TelescopioDTOMapper.FromDTO(dto));
        }
    }
}
