using StellarMinds.Enums;

namespace StellarMindsWebAPP.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Rol { get; set; }
        public string Pais { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public string Calle { get; set; } = string.Empty;
    }
}
