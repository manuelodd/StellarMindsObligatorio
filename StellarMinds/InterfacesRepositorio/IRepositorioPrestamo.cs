using StellarMinds.Entities;
using StellarMinds.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;
using static StellarMinds.InterfacesRepositorio.IRepositorio;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioPrestamo : IRepositorio<Prestamo>
    {
        public IEnumerable<Prestamo> FindPrestamosSocio(int socioId);
        public IEnumerable<Prestamo> FindPrestamosSocioEntreFechas(int socioId, int mes, int anio);
        public void Devolver(int id);
    }
}
