using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUObservacion
{
    public class AltaObservacionCU : IAltaObservacion
    {
        private IRepositorioObservacion repositorio;
        private IRepositorioPrestamo repositorioP;
        private IRepositorioObjetoCeleste repositorioOC;


        public AltaObservacionCU    (IRepositorioObservacion repo,
                                    IRepositorioPrestamo repoP,
                                    IRepositorioObjetoCeleste repoOC)
        {
            repositorio = repo;
            repositorioP = repoP;
            repositorioOC = repoOC;
        }
        public void Execute(ObservacionDTO dto)
        {
            Observacion observacion = ObservacionDTOMapper.FromDTO(dto);
            observacion.Prestamo = repositorioP.FindById(dto.PrestamoId);
            observacion.ObjetoCeleste = repositorioOC.FindById(dto.ObjetoCelesteId);
            repositorio.Alta(observacion);
        }
    }
}
