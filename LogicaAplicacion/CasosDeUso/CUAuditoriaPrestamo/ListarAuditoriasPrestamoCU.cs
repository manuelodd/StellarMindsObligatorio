using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUAuditoriaPrestamo
{
    public class ListarAuditoriasPrestamoCU : IListarAuditoriasPrestamo
    {
        private IRepositorioAuditoriaPrestamo repositorio;

        public ListarAuditoriasPrestamoCU(IRepositorioAuditoriaPrestamo repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<AuditoriaPrestamoDTO> Execute()
        {
            List<AuditoriaPrestamoDTO> aRetornar = new List<AuditoriaPrestamoDTO>();

            foreach(AuditoriaPrestamo audi in repositorio.FindAll())
            {
                aRetornar.Add(AuditoriaPrestamoDTOMapper.ToDTO(audi));
            }

            return aRetornar;
        }
    }
}
