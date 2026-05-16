using DTOs.DTOs;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class TelescopioDTOMapper
    {
        public static TelescopioDTO ToDto(Telescopio unTelescopio)
        {
            return new TelescopioDTO
            {
                Id = unTelescopio.Id,
                Marca = unTelescopio.Marca,
                Modelo = unTelescopio.Modelo,
                CantDisp = unTelescopio.CantDisp,
                Apertura = unTelescopio.Apertura,
                RelacionFocal = unTelescopio.RelacionFocal,
                DistanciaFocal = unTelescopio.DistanciaFocal,
                PesoKG = unTelescopio.PesoKG,
            };
        }

        public static Telescopio FromDTO(TelescopioDTO dto)
        {
            return new Telescopio
            {
                Id = dto.Id,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                CantDisp = dto.CantDisp,
                Apertura = dto.Apertura,
                RelacionFocal = dto.RelacionFocal,
                DistanciaFocal = dto.DistanciaFocal,
                PesoKG = dto.PesoKG,
            };
        }
    }
}
