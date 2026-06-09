namespace StellarMindsWebAPP.Models
{
    public class AuditoriaPrestamoModel
    {
            public int Id { get; set; }
            public DateTime Fecha { get; set; }
            public string Accion { get; set; } = string.Empty;
            public int PrestamoId { get; set; }
            public int CoordinadorId { get; set; }
            public int SocioId { get; set; }
            public string SocioNombre { get; set; } = string.Empty;
            public string CoordinadorNombre { get; set; } = string.Empty;
        
    }
}
