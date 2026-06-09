
using StellarMindsWebAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMindsWebApp.AuxiliarViewmodel
{
    
    public class PrestamoDevolucionViewmodel
    {
            public int? SocioId { get; set; }
            public int? PrestamoId { get; set; }
            public IEnumerable<UsuarioModel> Socios { get; set; }
            public IEnumerable<PrestamoModel> Prestamos { get; set; }
        }
}
