namespace StellarMindsWebAPP.Models
{
    public class TelescopioModel : EquipoModel
    {
        public decimal Apertura { get; set; }
        public string RelacionFocal { get; set; } = string.Empty;
        public decimal DistanciaFocal { get; set; }
        public decimal PesoKG { get; set; }
    }
}
