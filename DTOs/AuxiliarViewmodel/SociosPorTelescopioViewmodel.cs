using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.AuxiliarViewmodel
{
    public class SociosPorTelescopioViewModel
    {
        public IEnumerable<TelescopioDTO> Telescopios { get; set; }
        public IEnumerable<UsuarioDTO> Socios { get; set; }
    }
}
