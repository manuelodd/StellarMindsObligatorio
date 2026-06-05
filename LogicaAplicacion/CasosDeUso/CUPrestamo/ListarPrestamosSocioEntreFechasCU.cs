using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using StellarMinds.Entities;
using StellarMinds.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUPrestamo
{
    public class ListarPrestamosSocioEntreFechasCU : IListarPrestamosSocioEntreFechas
    {
        private IRepositorioPrestamo repositorio;

        public ListarPrestamosSocioEntreFechasCU(IRepositorioPrestamo repo)
        {
            repositorio = repo;
        }
        public List<PrestamoDTO> Execute(int socioId, int mes, int anio)
        {
            List<PrestamoDTO> listado = new List<PrestamoDTO>();

            foreach (Prestamo prestamo in repositorio.FindPrestamosSocioEntreFechas(socioId, mes, anio))
            {
                listado.Add(PrestamoDTOMapper.ToDTO(prestamo));
            }
            return listado;
        }
    }
}
