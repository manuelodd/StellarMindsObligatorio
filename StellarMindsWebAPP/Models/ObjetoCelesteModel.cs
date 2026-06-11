using StellarMinds.Enums;

namespace StellarMindsWebAPP.Models
{
    public class ObjetoCelesteModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string TipoObjetoCeleste { get; set; }
        public decimal MagnitudAparente { get; set; }
    }
}
