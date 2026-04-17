using LogicaAccesoDatos;
using StellarMinds.Entities;

namespace LogicaAplicacion
{
    public class AltaUsuarioCU
    {
        private RepositorioUsuario repositorio;


        public AltaUsuarioCU()
        {
            repositorio = new RepositorioUsuario();
        }


        public void AltaUsuario(Usuario unUsuario)
        {
            repositorio.AltaUsuario(unUsuario);
        }
    }
}
