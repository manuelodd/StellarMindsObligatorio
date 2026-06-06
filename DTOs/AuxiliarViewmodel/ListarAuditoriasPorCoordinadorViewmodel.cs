using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.AuxiliarViewmodel
{
    public class ListarAuditoriasPorCoordinadorViewmodel
    {
        public IEnumerable<UsuarioDTO> Coordinadores {  get; set; }
        public IEnumerable<AuditoriaPrestamoDTO> Auditorias { get; set; }

    }
}

