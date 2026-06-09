namespace StellarMindsWebAPP.Models
{
    public class PrestamoModel
    {
        public int Id { get; set; }
        public int SocioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
        public bool Atrasado { get; set; }
        public int TelescopioID { get; set; }
        public int MonturaID { get; set; }
        public int? CamaraID { get; set; }
        public int? OcularID { get; set; }
    }
}
