namespace StellarMindsWebAPP.Models
{
    public class EquipoModel
    {

            public int Id { get; set; }

            public string Marca { get; set; }
            public string Modelo { get; set; }
            public int CantDisp { get; set; }

            //evaluar el tipo del objeto (tele, montu, cam, ocu)
            public bool EnPrestamo { get; set; }
            public string Tipo { get; set; }
        
    }
}
