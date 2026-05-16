using DTOs.DTOs;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class OcularDTOMapper
    {
        public static OcularDTO ToDto(Ocular unOcular)
        {
            return new OcularDTO
            {
                Id = unOcular.Id,
                Marca = unOcular.Marca,
                Modelo = unOcular.Modelo,
                CantDisp = unOcular.CantDisp,
                Diametro = unOcular.Diametro,
                GradosVision = unOcular.GradosVision,
                
            };
        }

        public static Ocular FromDTO(OcularDTO dto)
        {
            return new Ocular
            {
                Id = dto.Id,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                CantDisp = dto.CantDisp,
                Diametro = dto.Diametro,
                GradosVision = dto.GradosVision,
            };
        }
    }
}
