using Dominio.Entities;
using StellarMinds.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;
using static StellarMinds.InterfacesRepositorio.IRepositorio;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioAuditoriaPrestamoEF : IRepositorio<AuditoriaPrestamo>
    {
        public void Alta(AuditoriaPrestamo aAgregar)
        {
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuditoriaPrestamo> FindAll()
        {
            throw new NotImplementedException();
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
