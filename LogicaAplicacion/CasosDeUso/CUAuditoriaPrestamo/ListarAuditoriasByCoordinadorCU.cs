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
    public class ListarAuditoriasByCoordinadorCU : IListarAuditoriasByCoordinador
    {
        private IRepositorioAuditoriaPrestamo repositorio;

        public ListarAuditoriasByCoordinadorCU(IRepositorioAuditoriaPrestamo repositorio)
        {
            this.repositorio = repositorio;
        }
        public IEnumerable<AuditoriaPrestamoDTO> Execute(int coordinadorId)
        {
            List<AuditoriaPrestamoDTO> listado = new List<AuditoriaPrestamoDTO>();

            foreach (AuditoriaPrestamo audi in repositorio.FindAllbyCoordinador(coordinadorId))
            {
                listado.Add(AuditoriaPrestamoDTOMapper.ToDTO(audi));
            }

            return listado;
        }
    }
}
