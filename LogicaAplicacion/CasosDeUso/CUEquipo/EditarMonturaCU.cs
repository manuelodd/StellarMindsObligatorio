using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUEquipo
{
    public class EditarMonturaCU : IEditarMontura
    {

        private IRepositorioEquipo repo;

        public EditarMonturaCU(IRepositorioEquipo repo)
        {
            this.repo = repo;
        }
        public void Execute(MonturaDTO dto)
        {
            repo.EditMontura(MonturaDTOMapper.FromDTO(dto));
        }
    }
}
