using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class OcularDTO : EquipoDTO
    {
        /*
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int CantDisp { get; set; }
        */
        public decimal Diametro { get; set; }
        public decimal GradosVision { get; set; }
    }
}


