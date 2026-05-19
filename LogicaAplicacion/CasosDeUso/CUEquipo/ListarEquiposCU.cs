using Dominio.InterfacesRepositorio;
using LogicaAplicacion.InterfacesCasosDeUso;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUEquipo
{
    public class ListarEquiposCU : IListarEquipos
    {
        private IRepositorioEquipo repositorio;

        public ListarEquiposCU(IRepositorioEquipo repo)
        {
            repositorio = repo;
        }
        public List<Equipo> Execute()
        {
            List<Equipo> equipos = null;
            foreach(Equipo equipo in repositorio.FindAll())
            {
                equipos.Add(equipo);
            }
            return equipos;
        }
    }
}
