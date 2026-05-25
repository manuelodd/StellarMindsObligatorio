using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUPrestamo
{
    public class ListarPrestamosCU : IListarPrestamos
    {

        private IRepositorioPrestamo repositorio;

        public ListarPrestamosCU(IRepositorioPrestamo repo)
        {
            repositorio = repo;
        }

        public List<PrestamoDTO> Execute()
        {
            List<PrestamoDTO> listado = new List<PrestamoDTO>();
            foreach(Prestamo prestamo in repositorio.FindAll())
            {
                listado.Add(PrestamoDTOMapper.ToDTO(prestamo));
            }
            return listado;
        }
    }
}
