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
                EnPrestamo = unaCamara.EnPrestamo,
                CantDisp = unaCamara.CantDisp,
                TipoSensor = unaCamara.TipoSensor.Value,
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
                EnPrestamo = dto.EnPrestamo,
                CantDisp = dto.CantDisp,
                TipoSensor = dto.TipoSensor,
                Resolution = dto.Resolution,
                PixelSize = dto.PixelSize,
            };
        }
    }
}
