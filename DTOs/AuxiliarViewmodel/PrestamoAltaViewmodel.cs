using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.AuxiliarViewmodel
{
    public class PrestamoAltaViewmodel
    {
        public IEnumerable<UsuarioDTO> Usuarios { get; set; }
        public IEnumerable<TelescopioDTO> Telescopios { get; set; }
        public IEnumerable<MonturaDTO> Monturas { get; set; }
        public IEnumerable<CamaraDTO> Camaras { get; set; }
        public IEnumerable<OcularDTO> Oculares { get; set; }
    }
}
