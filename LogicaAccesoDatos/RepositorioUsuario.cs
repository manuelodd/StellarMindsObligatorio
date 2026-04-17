using Dominio.Exceptions;
using StellarMinds.Entities;

namespace LogicaAccesoDatos
{
    public class RepositorioUsuario
    {

        // el "almacen" de _usuarios que teniamos en sistema ahora esta en su correspondiente repositorio"
        private List<Usuario> _usuarios;
        
        // que se inicializa al instanciar RepositorioUsuario
        public RepositorioUsuario()
        {
            _usuarios = new List<Usuario>();
        }

        // el alta se implementa acá
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
    }
}
