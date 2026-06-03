using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUObjetoCeleste
{
    public class ListarObjetosCelestesCU : IListarObjetosCelestes
    {

        private IRepositorioObjetoCeleste repositorio;

        public ListarObjetosCelestesCU(IRepositorioObjetoCeleste repo)
        {
            repositorio = repo;
        }
        public IEnumerable<ObjetoCelesteDTO> Execute()
        {
            List<ObjetoCelesteDTO> aRetornar = new List<ObjetoCelesteDTO>();
            foreach (ObjetoCeleste objeto in repositorio.FindAll())
            {
                aRetornar.Add(ObjetoCelesteDTOMapper.ToDTO(objeto));
            }
            return aRetornar;
        }
    }
}