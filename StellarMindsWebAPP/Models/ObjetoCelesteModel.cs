namespace StellarMindsWebAPP.Models
{
    public class ObjetoCelesteModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; }
        public decimal MagnitudAparente { get; set; }
    }
}
