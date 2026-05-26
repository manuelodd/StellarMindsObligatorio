using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Auxiliares
{
    public class PrestamoAltaViewmodel
    {
            public IEnumerable<TelescopioDTO> Telescopios { get; set; }

            public IEnumerable<MonturaDTO> Monturas { get; set; }

            public IEnumerable<CamaraDTO> Camaras { get; set; }

            public IEnumerable<OcularDTO> Oculares { get; set; }
        }
    }
