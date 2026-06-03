using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioObjetoCelesteEF : IRepositorioObjetoCeleste
    {
        private StellarMindsContext _context;
        public RepositorioObjetoCelesteEF(StellarMindsContext context)
        {
            _context = context;
        }
        public void Alta(ObjetoCeleste aAgregar)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObjetoCeleste> FindAll()
        {
            return _context.ObjetosCelestes
                                        .ToList();
        }

        public ObjetoCeleste FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ObjetoCeleste aActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
