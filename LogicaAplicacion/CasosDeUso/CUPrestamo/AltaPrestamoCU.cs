using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using StellarMinds.Entities;
using StellarMinds.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUPrestamo
{
    public class AltaPrestamoCU : IAltaPrestamo
    {
        private IRepositorioPrestamo repositorioPrestamo;
        private IRepositorioEquipo repositorioEquipo;

        public AltaPrestamoCU(IRepositorioPrestamo repo, 
                              IRepositorioEquipo repoE)
        {
            repositorioPrestamo = repo;
            repositorioEquipo = repoE;
        }

        public void Execute(PrestamoDTO dto)
        {
            Telescopio tele = repositorioEquipo.FindTeleById(dto.TelescopioID);
            Montura montu = repositorioEquipo.FindMontuById(dto.MonturaID);
            Camara cam = null;
            Ocular ocu = null;

            if (dto.CamaraID != null)   {   
                cam = repositorioEquipo.FindCamaById(dto.CamaraID);
            }

            if (dto.OcularID != null)   {
                ocu = repositorioEquipo.FindOcuById(dto.OcularID);
            }

            Prestamo prestamo = new Prestamo
            {
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Estado = EstadoPrestamo.EN_PRESTAMO,
                Telescopio = tele,
                Montura = montu,
                Camara = cam,
                Ocular = ocu
            };

            repositorioPrestamo.Alta(prestamo);
        }
    }
}
