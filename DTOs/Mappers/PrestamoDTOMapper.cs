using Dominio.InterfacesRepositorio;
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
                    TelescopioID = unPrestamo.Telescopio.Id,
                    MonturaID = unPrestamo.Montura.Id,
                    CamaraID = unPrestamo.Camara.Id,
                    OcularID = unPrestamo.Ocular.Id
                };
            }

        
        /*
        public static Prestamo FromDTO(PrestamoDTO dto)
        {
            return new Prestamo
            {
                Id = dto.Id,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Estado = dto.Estado,
                Telescopio = dto.TelescopioID,
                Montura = dto.MonturaID,
                Camara = dto.CamaraID,
                Ocular = dto.OcularID
            };
        */
        }
    }
    
