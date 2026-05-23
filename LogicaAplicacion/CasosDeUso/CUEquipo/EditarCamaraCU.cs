using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUEquipo
{
    public class EditarCamaraCU : IEditarCamara
    {

        private IRepositorioEquipo repo;

        public EditarCamaraCU(IRepositorioEquipo repo)
        {
            this.repo = repo;
        }
        public void Execute(CamaraDTO dto)
        {
            repo.EditCamara(CamaraDTOMapper.FromDTO(dto));
        }
    }
}
