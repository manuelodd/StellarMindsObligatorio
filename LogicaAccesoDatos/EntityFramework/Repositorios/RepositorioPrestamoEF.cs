using Dominio.InterfacesRepositorio;
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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Prestamo> FindAll()
        {
            throw new NotImplementedException();
        }

        public Prestamo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Prestamo aActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
