using Dominio.Entities;
using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using LogicaAplicacion.CasosDeUso.CUUsuario;
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
        private IRepositorioUsuario repositorioUsuario;
        private IRepositorioAuditoriaPrestamo repositorioAuditoriaPrestamo;

        public AltaPrestamoCU(IRepositorioPrestamo repo, 
                              IRepositorioEquipo repoE,
                              IRepositorioUsuario repoU,
                              IRepositorioAuditoriaPrestamo repoA)
        {
            repositorioPrestamo = repo;
            repositorioEquipo = repoE;
            repositorioUsuario = repoU;
            repositorioAuditoriaPrestamo = repoA;
        }

        public void Execute(PrestamoDTO dto, int coordinador)
        {
            Telescopio tele = repositorioEquipo.FindTeleById(dto.TelescopioID);
            Montura montu = repositorioEquipo.FindMontuById(dto.MonturaID);
            Camara cam = null;
            Ocular ocu = null;

            if (dto.CamaraID != null)   {   
                // value extrae el entero de el nulleable 
                cam = repositorioEquipo.FindCamaById(dto.CamaraID.Value);
            }

            if (dto.OcularID != null)   {
                ocu = repositorioEquipo.FindOcuById(dto.OcularID.Value);
            }

            Usuario socio = repositorioUsuario.FindById(dto.SocioId);

            Prestamo prestamo = new Prestamo
            {
                Socio = socio,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Estado = EstadoPrestamo.EN_PRESTAMO,
                Telescopio = tele,
                Montura = montu,
                Camara = cam,
                Ocular = ocu
            };

            prestamo.Validar();
            tele.CantDisp--;
            montu.CantDisp--;
            if (cam != null) cam.CantDisp--;
            if (ocu != null) ocu.CantDisp--;

            repositorioPrestamo.Alta(prestamo);

            AuditoriaPrestamo auditoria = new AuditoriaPrestamo
            {
                Fecha = DateTime.Now,
                Accion = "CREACIÓN",
                PrestamoId = prestamo.Id,
                Prestamo = prestamo,
                CoordinadorId = coordinador,
                Coordinador = repositorioUsuario.FindById(coordinador),
            };

            repositorioAuditoriaPrestamo.Alta(auditoria);


            /*        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; } = string.Empty;
        public int PrestamoId { get; set; }
        public int CoordinadorId { get; set; }
        public Prestamo Prestamo { get; set; }
        public Usuario Coordinador { get; set; }*/
        }
    }
}
