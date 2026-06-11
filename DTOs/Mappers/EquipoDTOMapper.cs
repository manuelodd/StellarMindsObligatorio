using DTOs.DTOs;
using StellarMinds.Entities;
using StellarMinds.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class EquipoDTOMapper
    {
        public static Telescopio FromDTOTele(TelescopioDTO dto)
        {
            return new Telescopio
            {
                Id = dto.Id,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                CantDisp = dto.CantDisp,
                EnPrestamo = dto.EnPrestamo,
                Apertura = dto.Apertura,
                RelacionFocal = dto.RelacionFocal,
                DistanciaFocal = dto.DistanciaFocal,
                PesoKG = dto.PesoKG,
            };
        }


        public static Montura FromDTOMontu(MonturaDTO dto)
        {
            return new Montura
            {
                Id = dto.Id,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                CantDisp = dto.CantDisp,
                EnPrestamo = dto.EnPrestamo,
                Tipo = Enum.Parse<TipoMontura>(dto.Tipo),
                CargaKG = dto.CargaKG,
                GoTo = dto.GoTo,
            };
        }

        public static Camara FromDTOCama(CamaraDTO dto)
        {
            return new Camara
            {
                Id = dto.Id,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                CantDisp = dto.CantDisp,
                EnPrestamo = dto.EnPrestamo,
                TipoSensor = Enum.Parse<TipoSensor>(dto.TipoSensor),
                Resolution = dto.Resolution,
                PixelSize = dto.PixelSize,
            };
        }

        public static Ocular FromDTOOcu(OcularDTO dto)
        {
            return new Ocular
            {
                Id = dto.Id,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                CantDisp = dto.CantDisp,
                EnPrestamo = dto.EnPrestamo,
                Diametro = dto.Diametro,
                GradosVision = dto.GradosVision,
            };
        }


        public static EquipoDTO ToListDTO(Equipo unEquipo)
        {
            string tipo = "";
            if (unEquipo is Telescopio) tipo = "Telescopio";
            if (unEquipo is Montura) tipo = "Montura";
            if (unEquipo is Camara) tipo = "Cámara";
            if (unEquipo is Ocular) tipo = "Ocular";

            return new EquipoDTO
            {
                Id = unEquipo.Id,
                Marca = unEquipo.Marca,
                Modelo = unEquipo.Modelo,
                EnPrestamo = unEquipo.EnPrestamo,
                CantDisp = unEquipo.CantDisp,
                Tipo = tipo,
            };
        }


        public static EquipoDTO ToDetailDTO(Equipo equipo)
        {
            if (equipo is Ocular ocular)
            {
                return new OcularDTO
                {
                    Id = ocular.Id,
                    Marca = ocular.Marca,
                    Modelo = ocular.Modelo,
                    EnPrestamo = ocular.EnPrestamo,
                    CantDisp = ocular.CantDisp,
                    Diametro = ocular.Diametro,
                    GradosVision = ocular.GradosVision
                };
            }

            if (equipo is Telescopio telescopio)
            {
                return new TelescopioDTO
                {
                    Id = telescopio.Id,
                    Marca = telescopio.Marca,
                    Modelo = telescopio.Modelo,
                    EnPrestamo = telescopio.EnPrestamo,
                    CantDisp = telescopio.CantDisp,
                    Apertura = telescopio.Apertura,
                    RelacionFocal = telescopio.RelacionFocal,
                    DistanciaFocal = telescopio.DistanciaFocal,
                    PesoKG = telescopio.PesoKG
                };
            }

            if (equipo is Montura montura)
            {
                return new MonturaDTO
                {
                    Id = montura.Id,
                    Marca = montura.Marca,
                    Modelo = montura.Modelo,
                    EnPrestamo = montura.EnPrestamo,
                    CantDisp = montura.CantDisp,
                    Tipo = montura.Tipo.ToString(),
                    CargaKG = montura.CargaKG,
                    GoTo = montura.GoTo,
                };
            }

            if (equipo is Camara camara)
            {
                return new CamaraDTO
                {
                    Id = camara.Id,
                    Marca = camara.Marca,
                    Modelo = camara.Modelo,
                    EnPrestamo = camara.EnPrestamo,
                    CantDisp = camara.CantDisp,
                    TipoSensor = camara.TipoSensor.ToString(),
                    Resolution = camara.Resolution,
                    PixelSize = camara.PixelSize,
                };
            }


            return null;
        }
    }
}
