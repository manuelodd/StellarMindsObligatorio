using Dominio.Entities;
using DTOs.DTOs;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class AuditoriaPrestamoDTOMapper
    {
        public static AuditoriaPrestamoDTO ToDTO(AuditoriaPrestamo unaAudi)
        {
            return new AuditoriaPrestamoDTO
            {
                Id = unaAudi.Id,
                Fecha = unaAudi.Fecha,
                Accion = unaAudi.Accion,
                CoordinadorId = unaAudi.CoordinadorId,
                PrestamoId = unaAudi.PrestamoId,
            };
        }
    }
}
