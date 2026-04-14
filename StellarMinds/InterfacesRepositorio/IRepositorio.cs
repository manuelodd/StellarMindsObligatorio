using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.InterfacesRepositorio
{
    public interface IRepositorio
    {
        public interface IRepositorio<T> where T : class
        {
            public void Alta(T aAgregar);
            public void Delete(int id);
            public void Update(T aActualizar);
            public IEnumerable<T> FindAll();
            public T FindById(int id);
        }
    }
}
