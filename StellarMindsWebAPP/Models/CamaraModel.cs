using StellarMinds.Enums;

namespace StellarMindsWebAPP.Models
{
    public class CamaraModel : EquipoModel
    {
        public TipoSensor TipoSensor { get; set; }
        public int Resolution { get; set; }
        public decimal PixelSize { get; set; }



    }
}
