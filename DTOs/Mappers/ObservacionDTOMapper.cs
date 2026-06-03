using DTOs.AuxiliarViewmodel;
using DTOs.DTOs;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class ObservacionDTOMapper
    {
        public static ObservacionDTO ToDTO(Observacion observacion)
        {
            return new ObservacionDTO
            {
                Id = observacion.Id,
                Fecha = observacion.Fecha,
                PrestamoId = observacion.PrestamoId,
                ObjetoCelesteId = observacion.ObjetoCelesteId,
                Indicador = "ToDo",
                Detalle = "ToDo"
            };
        }

        public static Observacion FromDTO(ObservacionDTO dto)
        {
            return new Observacion
            {
                Id = dto.Id,
                Fecha = dto.Fecha,
                PrestamoId = dto.PrestamoId,
                ObjetoCelesteId = dto.ObjetoCelesteId,
                Indicador = "ToDo",
                Detalle = "ToDo"
            };
        }
    }
}
