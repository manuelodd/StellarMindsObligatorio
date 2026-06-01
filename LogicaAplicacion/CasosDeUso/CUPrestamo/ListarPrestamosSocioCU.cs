using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using StellarMinds.Entities;
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

            foreach (Prestamo pres in repositorio.FindPrestamosSocio(socioId))
            {
                lista.Add(PrestamoDTOMapper.ToDTO(pres));
            }
            return lista;
        }
    }
}
