using Dominio.InterfacesRepositorio;
using LogicaAplicacion.InterfacesCasosDeUso;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUPrestamo
{
    public class ReturnPrestamoCU : IReturnPrestamo
    {
        private IRepositorioPrestamo repositorio;

        public ReturnPrestamoCU(IRepositorioPrestamo repo)
        {
            repositorio = repo;
        }
        public void Execute(int id)
        {
            repositorio.Devolver(id);
        }
    }
}
