using DTOs.DTOs;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class MonturaDTOMapper
    {
        public static MonturaDTO ToDto(Montura unaMontura)
        {
            return new MonturaDTO
            {
                Id = unaMontura.Id,
                Marca = unaMontura.Marca,
                Modelo = unaMontura.Modelo,
                CantDisp = unaMontura.CantDisp,
                Tipo = unaMontura.Tipo,
                CargaKG = unaMontura.CargaKG,
                GoTo = unaMontura.GoTo,
            };
        }

        public static Montura FromDTO(MonturaDTO dto)
        {
            return new Montura
            {
                Id = dto.Id,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                CantDisp = dto.CantDisp,
                Tipo = dto.Tipo,
                CargaKG = dto.CargaKG,
                GoTo = dto.GoTo,
            };
        }
    }
}
