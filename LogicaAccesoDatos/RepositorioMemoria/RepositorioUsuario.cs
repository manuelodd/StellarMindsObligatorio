using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
using StellarMinds.Entities;
using StellarMinds.Enums;
using System.Runtime.InteropServices.Marshalling;

namespace LogicaAccesoDatos.RepositorioMemoria
{
    public class RepositorioUsuario : IRepositorioUsuario
    {

        // el "almacen" de _usuarios que teniamos en sistema ahora esta en su correspondiente repositorio"
        public static List<Usuario> _usuarios = new List<Usuario>();        
        // que se inicializa al instanciar RepositorioUsuario
        public RepositorioUsuario()
        {
            _usuarios = new List<Usuario>();
        }

        // el alta y se implementa acá

        public void AltaUsuario(Usuario unUsuario) 
        {
            try
            {
                unUsuario.Validar();
                _usuarios.Add(unUsuario);
            }
            catch (InvalidUser ex)
            {
                
            }
        }

        public void Alta(Usuario aAgregar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindAll()
        {
            return _usuarios;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario aActualizar)
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
