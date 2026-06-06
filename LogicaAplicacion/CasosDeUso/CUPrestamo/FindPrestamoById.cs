using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUPrestamo
{
    public class FindPrestamoById : IFindPrestamoById
    {
        private IRepositorioPrestamo repositorio;

        public FindPrestamoById(IRepositorioPrestamo repo)
        {
            repositorio = repo;
        }

        public PrestamoDTO Execute(int id)
        {
            return PrestamoDTOMapper.ToDTO(repositorio.FindById(id));
        }
    }
    }

