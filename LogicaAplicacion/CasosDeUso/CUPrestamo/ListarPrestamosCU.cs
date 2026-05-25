using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}
