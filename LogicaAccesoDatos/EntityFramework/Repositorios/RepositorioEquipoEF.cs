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

        public void EditMontura(Montura aEditar)
        {
            Montura montu = _context.Monturas
                .FirstOrDefault(t => t.Id == aEditar.Id);

            if (montu != null)
            {
                montu.Marca = aEditar.Marca;
                montu.Modelo = aEditar.Modelo;
                montu.CantDisp = aEditar.CantDisp;
                montu.Tipo = aEditar.Tipo;
                montu.CargaKG = aEditar.CargaKG;
                montu.GoTo = aEditar.GoTo;
                _context.SaveChanges();
            }
        }

        public void EditCamara(Camara aEditar)
        {
            Camara cama = _context.Suscripciones
                .FirstOrDefault(t => t.Id == aEditar.Id);

            if (cama != null)
            {
                cama.Marca = aEditar.Marca;
                cama.Modelo = aEditar.Modelo;
                cama.CantDisp = aEditar.CantDisp;
                cama.TipoSensor = aEditar.TipoSensor;
                cama.Resolution = aEditar.Resolution;
                cama.PixelSize = aEditar.PixelSize;
                _context.SaveChanges();
            }
        }

        public void EditOcular(Ocular aEditar)
        {
            Ocular ocu = _context.Oculares
                .FirstOrDefault(t => t.Id == aEditar.Id);

            if (ocu != null)
            {
                ocu.Marca = aEditar.Marca;
                ocu.Modelo = aEditar.Modelo;
                ocu.CantDisp = aEditar.CantDisp;
                ocu.Diametro = aEditar.Diametro;
                ocu.GradosVision = aEditar.GradosVision;
                _context.SaveChanges();
            }
        }






        public void Update(Equipo aActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
