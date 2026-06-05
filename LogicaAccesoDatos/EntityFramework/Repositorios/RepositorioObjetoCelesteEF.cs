using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioObjetoCelesteEF : IRepositorioObjetoCeleste
    {
        private StellarMindsContext _context;
        public RepositorioObjetoCelesteEF(StellarMindsContext context)
        {
            _context = context;
        }
        public void Alta(ObjetoCeleste aAgregar)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObjetoCeleste> FindAll()
        {
            return _context.ObjetosCelestes
                                        .ToList();
        }

        public ObjetoCeleste FindById(int id)
        {
            return _context.ObjetosCelestes
                                        .Where(oc => oc.Id == id)
                                        .FirstOrDefault();
        }

        public IEnumerable<RankingObjetoCelesteDTO> RankingObjetos()
        {
            return _context.Observaciones
                .GroupBy(o => o.ObjetoCeleste)
                .Select(g => new RankingObjetoCelesteDTO
                {
                    Nombre = g.Key.Nombre,
                    Tipo = g.Key.Tipo,
                    CantidadObservaciones = g.Count()
                })
                .OrderByDescending(x => x.CantidadObservaciones)
                .ToList();
        }

        public void Update(ObjetoCeleste aActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
