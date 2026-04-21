using Dominio.InterfacesRepositorio;
using Dominio.ValueObjects;
using DTOs.DTOS;
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
            Usuario unUsuario = new Usuario();
            unUsuario.Id = dto.Id;
            unUsuario.NombreCompleto = new UsuarioNombreCompleto(dto.Nombre, dto.Apellido);
            unUsuario.Telefono = dto.Telefono;
            unUsuario.Email = dto.Email;
            unUsuario.Username = dto.Username;
            unUsuario.Password = dto.Password;
            unUsuario.Rol = dto.Rol;
            unUsuario.Direccion = new UsuarioDireccion(dto.Pais, dto.Ciudad, dto.Calle);
            // y acá el alta usuario de repositorio (RepositorioUsuario) lo agrega a _usuarios
            repositorio.AltaUsuario(unUsuario);
        }
    }
}
