using Dominio.Entities;
using DTOs.DTOs;
using StellarMinds.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class ObjetoCelesteDTOMapper
    {
        public static ObjetoCelesteDTO ToDTO(ObjetoCeleste objeto)
        {
            return new ObjetoCelesteDTO
            {
                Id = objeto.Id,
                Nombre = objeto.Nombre,
                Tipo = objeto.Tipo.ToString(),
                MagnitudAparente = objeto.MagnitudAparente
            };
        }

        public static ObjetoCeleste FromDTO(ObjetoCelesteDTO dto)
        {
            return new ObjetoCeleste
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Tipo = Enum.Parse<TipoObjetoCeleste>(dto.Tipo),
                MagnitudAparente = dto.MagnitudAparente
            };
        }
    }
}
