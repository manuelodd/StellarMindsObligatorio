using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioEquipoEF : IRepositorioEquipo
    {
        private StellarMindsContext _context;
        public RepositorioEquipoEF(StellarMindsContext context)
        {
            _context = context;
        }
        /*
        public int EvaluarTipo(object equipo)
        {
            if (equipo is Telescopio) { return 1; }
            if (equipo is Montura) { return 2; }
            if (equipo is Camara) { return 3; }
            if (equipo is Ocular) { return 4; }
            return 0;
        }
        */

        public void Alta(Equipo unEquipo)
        {
            unEquipo.Validar();
            _context.Add(unEquipo);
            _context.SaveChanges();
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipo> FindAll()
        {
            return _context.Equipos;
        }

        public Equipo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Equipo FindEquipoPorID(int id)
        {
            return _context.Equipos.
                Where(equipo => equipo.Id == id)
                .FirstOrDefault();
        }

        public void EditTelescopio(Telescopio aEditar)
        {
            Telescopio tele = _context.Telescopios
                .FirstOrDefault(t => t.Id == aEditar.Id);

            if (aEditar != null)
            {
                tele.Marca = aEditar.Marca;
                tele.Modelo = aEditar.Modelo;
                tele.CantDisp = aEditar.CantDisp;
                tele.Apertura = aEditar.Apertura;
                tele.RelacionFocal = aEditar.RelacionFocal;
                tele.DistanciaFocal = aEditar.DistanciaFocal;
                tele.PesoKG = aEditar.PesoKG;
                _context.SaveChanges();
            }
        }

        public void Update(Equipo aActualizar)
        {
            throw new NotImplementedException();
        }


    }
}
