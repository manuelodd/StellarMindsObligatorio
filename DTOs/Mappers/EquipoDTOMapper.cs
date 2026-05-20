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
                    CantDisp = montura.CantDisp,
                    Tipo = montura.Tipo,
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
                    CantDisp = camara.CantDisp,
                    TipoSensor = camara.TipoSensor,
                    Resolution = camara.Resolution,
                    PixelSize = camara.PixelSize,
                };
            }


            return null;
        }
    }
}
