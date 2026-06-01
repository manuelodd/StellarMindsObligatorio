using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUPrestamo
{
    public class ListarPrestamosSocioCU : IListarPrestamosSocio
    {

        private IRepositorioPrestamo repositorio;

        public ListarPrestamosSocioCU(IRepositorioPrestamo repo)
        {
            repositorio = repo;
        }
        public List<PrestamoDTO> Execute(int socioId)
        {
            List<PrestamoDTO> lista = new List<PrestamoDTO>();

            foreach (Presta p in repositorio.FindPrestamosActivosSocio(socioId))
            {
                lista.Add(PrestamoDTOMapper.ToDTO(p));
            }

            return lista;
        }
    }
}
