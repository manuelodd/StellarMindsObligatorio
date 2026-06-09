namespace StellarMindsWebAPP.Models
{
    public class ObservacionModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int PrestamoId { get; set; }
        public int ObjetoCelesteId { get; set; }
        public string Indicador { get; set; } = string.Empty;
        public string Detalle { get; set; } = string.Empty;
    }
}
