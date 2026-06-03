using Dominio.InterfacesRepositorio;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioObservacionEF : IRepositorioObservacion
    {
        private StellarMindsContext _context;
        public RepositorioObservacionEF(StellarMindsContext context)
        {
            _context = context;
        }
        public void Alta(Observacion aAgregar)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Observacion> FindAll()
        {
            throw new NotImplementedException();
        }

        public Observacion FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Observacion aActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
