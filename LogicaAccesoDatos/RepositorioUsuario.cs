using Dominio.Exceptions;
using StellarMinds.Entities;

namespace LogicaAccesoDatos
{
    public class RepositorioUsuario
    {
        private List<Usuario> _usuarios;
        

        public RepositorioUsuario()
        {
            _usuarios = new List<Usuario>();
        }

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
