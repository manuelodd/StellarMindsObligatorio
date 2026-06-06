using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUAuditoriaPrestamo
{
    public class FindAuditoriaById : IFindAuditoriaById
    {
        private IRepositorioAuditoriaPrestamo repositorio;

        public FindAuditoriaById(IRepositorioAuditoriaPrestamo repositorio)
        {
            this.repositorio = repositorio;
        }
        public AuditoriaPrestamoDTO Execute(int id)
        {
            return AuditoriaPrestamoDTOMapper.ToDTO(repositorio.FindById(id));
        }
    }
}
