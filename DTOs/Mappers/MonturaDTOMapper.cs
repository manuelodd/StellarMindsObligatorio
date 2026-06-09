using DTOs.DTOs;
using StellarMinds.Entities;
using StellarMinds.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DTOs.Mappers
{
    public class MonturaDTOMapper
    {
        public static MonturaDTO ToDTO(Montura unaMontura)
        {
            return new MonturaDTO
            {
                Id = unaMontura.Id,
                Marca = unaMontura.Marca,
                Modelo = unaMontura.Modelo,
                EnPrestamo = unaMontura.EnPrestamo,
                CantDisp = unaMontura.CantDisp,
                Tipo = unaMontura.Tipo.ToString(),
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
                EnPrestamo = dto.EnPrestamo,
                CantDisp = dto.CantDisp,
                Tipo = Enum.Parse<TipoMontura>(dto.Tipo),
                CargaKG = dto.CargaKG,
                GoTo = dto.GoTo,
            };
        }
    }
}
