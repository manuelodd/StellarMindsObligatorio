using DTOs.DTOs;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class CamaraDTOMapper
    {
        public static CamaraDTO ToDTO(Camara unaCamara)
        {
            return new CamaraDTO
            {
                Id = unaCamara.Id,
                Marca = unaCamara.Marca,
                Modelo = unaCamara.Modelo,
                CantDisp = unaCamara.CantDisp,
                TipoSensor = unaCamara.TipoSensor,
                Resolution = unaCamara.Resolution,
                PixelSize = unaCamara.PixelSize,
            };
        }

        public static Camara FromDTO(CamaraDTO dto)
        {
            return new Camara
            {
                Id = dto.Id,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                CantDisp = dto.CantDisp,
                TipoSensor = dto.TipoSensor,
                Resolution = dto.Resolution,
                PixelSize = dto.PixelSize,
            };
        }
    }
}
