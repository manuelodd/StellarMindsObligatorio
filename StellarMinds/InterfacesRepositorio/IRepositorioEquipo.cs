using StellarMinds.Entities;
using StellarMinds.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;
using static StellarMinds.InterfacesRepositorio.IRepositorio;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioEquipo : IRepositorio<Equipo>
    {
        public Telescopio FindTeleById(int id);
        public Montura FindMontuById(int id);
        public Camara FindCamaById(int id);
        public Ocular FindOcuById(int id);

        public IEnumerable<Equipo> FindAllTelescopios();
        public IEnumerable<Equipo> FindAllMonturas();
        public IEnumerable<Equipo> FindAllCamaras();
        public IEnumerable<Equipo> FindAllOculares();
        public void EditTelescopio(Telescopio tele);
        public void EditMontura(Montura montu);
        public void EditCamara(Camara cama);
        public void EditOcular(Ocular ocu);

    }
}
