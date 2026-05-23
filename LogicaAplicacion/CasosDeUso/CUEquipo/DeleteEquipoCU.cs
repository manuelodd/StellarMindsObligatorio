using Dominio.InterfacesRepositorio;
using LogicaAplicacion.InterfacesCasosDeUso;
using StellarMinds.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUEquipo
{
    public class DeleteEquipoCU : IDeleteEquipo
    {
        private IRepositorioEquipo repositorio;

        public DeleteEquipoCU(IRepositorioEquipo repo)
        {
            repositorio = repo;
        }
        public void Execute(int id)
        {
            repositorio.Delete(id);
        }
    }
}
