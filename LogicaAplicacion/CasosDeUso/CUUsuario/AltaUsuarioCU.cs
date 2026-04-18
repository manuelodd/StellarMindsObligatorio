using Dominio.InterfacesRepositorio;
using LogicaAccesoDatos.RepositorioMemoria;
using StellarMinds.Entities;

namespace LogicaAplicacion.CasosDeUso.CUUsuario
{
    public class AltaUsuarioCU
    {
        // en vez de depender de un RepositorioUsuario, esperamos un objeto de tipo interfaz,
        // no queremos que dependa de la implementacion, queremos que dependa de la LN
        private IRepositorioUsuario repositorio;

        // al instanciar un AltaUsuarioCU se crea una List<Usuario> _usuarios 
        public AltaUsuarioCU(IRepositorioUsuario repo)
        {
            repositorio = repo;
        }


        public void AltaUsuario(Usuario unUsuario)
        {
            // y acá el alta usuario de repositorio (RepositorioUsuario) lo agrega a _usuarios
            repositorio.AltaUsuario(unUsuario);
        }
    }
}
