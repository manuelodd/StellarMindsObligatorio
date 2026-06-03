using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using LogicaAplicacion.InterfacesCasosDeUso;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUPrestamo
{
    public class ReturnPrestamoCU : IReturnPrestamo
    {
        private IRepositorioPrestamo repositorio;
        private IRepositorioAuditoriaPrestamo repositorioAuditoriaPrestamo;
        private IRepositorioUsuario repositorioUsuario;

        public ReturnPrestamoCU(IRepositorioPrestamo repo,
                                IRepositorioAuditoriaPrestamo repoA,
                                IRepositorioUsuario repoU)
        {
            repositorio = repo;
            repositorioAuditoriaPrestamo = repoA;
            repositorioUsuario = repoU;
        }
        public void Execute(int id, int coordinador)
        {
            Prestamo prestamo = repositorio.FindById(id);

            AuditoriaPrestamo auditoria = new AuditoriaPrestamo
            {
                Fecha = DateTime.Now,
                Accion = "DEVOLUCIÓN",
                PrestamoId = prestamo.Id,
                Prestamo = prestamo,
                CoordinadorId = coordinador,
                Coordinador = repositorioUsuario.FindById(coordinador),
            };

            repositorioAuditoriaPrestamo.Alta(auditoria);


            repositorio.Devolver(id);
        }
    }
}
