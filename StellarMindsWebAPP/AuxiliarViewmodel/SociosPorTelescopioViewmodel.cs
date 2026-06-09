
using StellarMindsWebAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMindsWebApp.AuxiliarViewmodel
{
    public class SociosPorTelescopioViewmodel
    {
        public IEnumerable<TelescopioModel> Telescopios { get; set; }
        public IEnumerable<UsuarioModel> Socios { get; set; }
    }
}
