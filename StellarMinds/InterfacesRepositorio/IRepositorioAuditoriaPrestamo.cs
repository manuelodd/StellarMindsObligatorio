using Dominio.Entities;
using StellarMinds.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;
using static StellarMinds.InterfacesRepositorio.IRepositorio;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioAuditoriaPrestamo : IRepositorio<AuditoriaPrestamo>
    {
        //public IEnumerable<AuditoriaPrestamo> Execute();
        public IEnumerable<AuditoriaPrestamo> FindAllbyCoordinador(int coordinadorId);
    }
}
