
using StellarMindsWebAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMindsWebApp.AuxiliarViewmodel
{
    public class ListarAuditoriasPorCoordinadorViewmodel
    {
        public IEnumerable<UsuarioModel> Coordinadores {  get; set; }
        public IEnumerable<AuditoriaPrestamoModel> Auditorias { get; set; }

    }
}

