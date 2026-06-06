using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using StellarMinds.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioAuditoriaPrestamoEF : IRepositorioAuditoriaPrestamo
    {
        private StellarMindsContext _context;
        public RepositorioAuditoriaPrestamoEF(StellarMindsContext context)
        {
            _context = context;
        }
        public void Alta(AuditoriaPrestamo aAgregar)
        {
            _context.Add(aAgregar);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuditoriaPrestamo> FindAllbyCoordinador(int coordinadorId)
        {
            return _context.AuditoriaPrestamo
                                            .Where(a => a.CoordinadorId == coordinadorId)
                                            .Include(a => a.Coordinador)
                                            .Include(a => a.Prestamo)
                                            .ToList();
        }

        public IEnumerable<AuditoriaPrestamo> FindAll()
        {
            return _context.AuditoriaPrestamo
                                            .Include(a => a.Coordinador)
                                            .Include(a => a.Prestamo)
                                            .ToList();
        }
        

        public AuditoriaPrestamo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AuditoriaPrestamo aActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
