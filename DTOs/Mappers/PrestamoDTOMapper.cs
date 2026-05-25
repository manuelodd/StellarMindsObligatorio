using DTOs.DTOs;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{

    /*        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public EstadoPrestamo Estado { get; set; }
        public Telescopio Telescopio { get; set; } = null;
        public Montura Montura { get; set; } = null;
        public Camara Camara { get; set; } = null;
        public Ocular Ocular { get; set; } = null;*/
    public class PrestamoDTOMapper
        {
            public static PrestamoDTO ToDTO(Prestamo unPrestamo)
            {
                return new PrestamoDTO
                {
                    Id = unPrestamo.Id,
                    FechaInicio = unPrestamo.FechaInicio,
                    FechaFin = unPrestamo.FechaFin,
                    Estado = unPrestamo.Estado,
                    Telescopio = unPrestamo.Telescopio,
                    Montura = unPrestamo.Montura,
                    Camara = unPrestamo.Camara,
                    Ocular = unPrestamo.Ocular
                };
            }
        public static Prestamo FromDTO(PrestamoDTO dto)
        {
            return new Prestamo
            {
                Id = dto.Id,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Estado = dto.Estado,
                Telescopio = dto.Telescopio,
                Montura = dto.Montura,
                Camara = dto.Camara,
                Ocular = dto.Ocular
            };
        }
    }
    }
