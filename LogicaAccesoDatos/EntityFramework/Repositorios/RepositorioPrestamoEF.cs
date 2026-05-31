using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioPrestamoEF : IRepositorioPrestamo
    {
        private StellarMindsContext _context;
        public RepositorioPrestamoEF(StellarMindsContext context)
        {
            _context = context;
        }


        public void Alta(Prestamo aAgregar)
        {
                aAgregar.Validar();
                _context.Prestamos.Add(aAgregar);
                _context.SaveChanges();
        }

        // not really a deletion
        public void Delete(int id)
        {
            Prestamo prestamo = FindById(id);
            if(prestamo.Estado != StellarMinds.Enums.EstadoPrestamo.DEVUELTO) 
            {
                prestamo.Telescopio.CantDisp++;
                prestamo.Montura.CantDisp++;
                if(prestamo.Camara != null) { prestamo.Camara.CantDisp++; }
                if(prestamo.Ocular != null) { prestamo.Ocular.CantDisp++; }
                prestamo.Estado = StellarMinds.Enums.EstadoPrestamo.DEVUELTO;
            }
        }

        public IEnumerable<Prestamo> FindAll()
        {
            return _context.Prestamos
                            .Include(p => p.Telescopio)
                            .Include(p => p.Montura)
                            .Include(p => p.Camara)
                            .Include(p => p.Ocular);
        }

        public Prestamo FindById(int id)
        {
            return _context.Prestamos
                            .Where(p => p.Id == id)
                            .FirstOrDefault();
        }

        public void Update(Prestamo aActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
