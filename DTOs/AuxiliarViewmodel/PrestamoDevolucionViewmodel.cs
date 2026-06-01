using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.AuxiliarViewmodel
{
    
    public class PrestamoDevolucionViewmodel
    {
            public int? SocioId { get; set; }
            public int? PrestamoId { get; set; }
            public IEnumerable<UsuarioDTO> Socios { get; set; }
            public IEnumerable<PrestamoDTO> Prestamos { get; set; }
        }
}
