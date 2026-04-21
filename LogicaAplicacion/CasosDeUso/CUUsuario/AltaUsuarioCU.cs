using Dominio.InterfacesRepositorio;
using Dominio.ValueObjects;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAccesoDatos.RepositorioMemoria;
using LogicaAplicacion.InterfacesCasosDeUso;
using StellarMinds.Entities;
using StellarMinds.ValueObjects;

namespace LogicaAplicacion.CasosDeUso.CUUsuario
{
    public class AltaUsuarioCU : IAltaUsuario
    {
        // en vez de depender de un RepositorioUsuario, esperamos un objeto de tipo interfaz,
        // no queremos que dependa de la implementacion, queremos que dependa de la LN
        private IRepositorioUsuario repositorio;

        // al instanciar un AltaUsuarioCU se crea una List<Usuario> _usuarios 
        public AltaUsuarioCU(IRepositorioUsuario repo)
        {
            repositorio = repo;
        }
        /*
                 public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set;  } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public RolUsuario Rol { get; set; }
        public string Pais { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public string Calle { get; set; } = string.Empty;
         */

        public void AltaUsuario(UsuarioDTO dto)
        {
            repositorio.Alta(UsuarioDTOMapper.FromDTO(dto));
        }
    }
}
