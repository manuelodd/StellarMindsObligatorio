using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUObjetoCeleste
{
    public class RankObjetosCelestesCU : IRankObjetosCelestes
    {
        private IRepositorioObservacion repositorio;

        public RankObjetosCelestesCU(IRepositorioObservacion repo)
        {
            repositorio = repo;
        }


        public List<RankObjetosCelestesDTO> Execute()
        {

            return repositorio.FindAll()
                                .GroupBy(o => o.ObjetoCeleste)
                                .Select(g => new RankObjetosCelestesDTO {
                                    //agrupo por ObjetoCeleste, Key es equivalente a ObjetoCeleste, agarro el nombre
                                    Nombre = g.Key.Nombre,
                                    //y agarro al tipo, conviertiendolo de enum a string also
                                    Tipo = g.Key.Tipo.ToString(),
                                    //CantidadObservaciones es igual a la cantidad de veces que aparece el objeto en cuestion (objceleste) que utilice en el GB
                                    CantidadObservaciones = g.Count()
                                })
                .OrderByDescending(c => c.CantidadObservaciones)
                .ToList();
        }




    }
}
