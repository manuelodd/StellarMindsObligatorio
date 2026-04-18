using LogicaAccesoDatos.RepositorioMemoria;
using StellarMinds.Entities;

namespace LogicaAplicacion.CasosDeUso.CUUsuario
{
    public class AltaUsuarioCU
    {

        private RepositorioUsuario repositorio;

        // al instanciar un AltaUsuarioCU se crea una List<Usuario> _usuarios 
        public AltaUsuarioCU()
        {
            repositorio = new RepositorioUsuario();
        }


        public void AltaUsuario(Usuario unUsuario)
        {
            // y acá el alta usuario de repositorio (RepositorioUsuario) lo agrega a _usuarios
            repositorio.AltaUsuario(unUsuario);
        }
    }
}
