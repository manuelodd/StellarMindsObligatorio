
using StellarMindsWebAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMindsWebApp.AuxiliarViewmodel
{
    public class ObservacionAltaViewmodel
    {
        public IEnumerable<PrestamoModel> Prestamos { get; set; }
        public IEnumerable<ObjetoCelesteModel> ObjetosCelestes { get; set; }
    }
}
