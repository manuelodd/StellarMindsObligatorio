using DTOs.DTOs;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class EquipoDTOMapper
    {
        public static EquipoDTO ToDto(Equipo unEquipo)
        {
            string tipo = "";
            if (unEquipo is Telescopio) tipo = "Telescopio";
            if (unEquipo is Montura) tipo = "Montura";
            if (unEquipo is Camara) tipo = "Cámara";
            if (unEquipo is Ocular) tipo = "Ocular";

            return new EquipoDTO
            {
                Id = unEquipo.Id,
                Marca = unEquipo.Marca,
                Modelo = unEquipo.Modelo,
                CantDisp = unEquipo.CantDisp,
                Tipo = tipo,
            };
        }
    }
}
