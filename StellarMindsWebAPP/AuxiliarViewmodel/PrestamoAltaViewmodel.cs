
using StellarMindsWebAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMindsWebApp.AuxiliarViewmodel
{
    public class PrestamoAltaViewmodel
    {
        public IEnumerable<UsuarioModel> Usuarios { get; set; }
        public IEnumerable<TelescopioModel> Telescopios { get; set; }
        public IEnumerable<MonturaModel> Monturas { get; set; }
        public IEnumerable<CamaraModel> Camaras { get; set; }
        public IEnumerable<OcularModel> Oculares { get; set; }
    }
}
