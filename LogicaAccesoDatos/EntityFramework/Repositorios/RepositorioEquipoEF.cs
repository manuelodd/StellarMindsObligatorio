using Dominio.InterfacesRepositorio;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioEquipoEF : IRepositorioEquipo
    {
        private StellarMindsContext _context;
        public RepositorioEquipoEF(StellarMindsContext context)
        {
            _context = context;
        }


        public void Alta(Equipo unEquipo)
        {
            unEquipo.Validar();
            _context.Add(unEquipo);
            _context.SaveChanges();
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipo> FindAll()
        {
            throw new NotImplementedException();
        }

        public Equipo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Equipo aActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
