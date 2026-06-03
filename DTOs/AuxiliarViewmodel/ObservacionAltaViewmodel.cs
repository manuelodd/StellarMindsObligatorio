using Dominio.Entities;
using DTOs.DTOs;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.AuxiliarViewmodel
{
    public class ObservacionAltaViewmodel
    {
        public IEnumerable<PrestamoDTO> Prestamos { get; set; }
        public IEnumerable<ObjetoCelesteDTO> ObjetosCelestes { get; set; }
    }
}
