using Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class Telescopio : Equipo
    {

        public decimal Apertura { get; set; }
        public string RelacionFocal { get; set; }
        public decimal DistanciaFocal { get; set; }
        public decimal PesoKG { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Marca))
                throw new InvalidEquipo("La marca no puede ser vacía.");
            if (string.IsNullOrEmpty(Modelo))
                throw new InvalidEquipo("El modelo no puede ser vacío.");
            if (CantDisp < 0)
                throw new InvalidEquipo("La cantidad disponible no puede ser negativa.");
            if (Apertura <= 0)
                throw new InvalidEquipo("La apertura debe ser mayor a 0.");
            if (string.IsNullOrEmpty(RelacionFocal))
                throw new InvalidEquipo("La relación focal no puede ser vacía.");
            if (DistanciaFocal <= 0)
                throw new InvalidEquipo("La distancia focal debe ser mayor a 0.");
            if (PesoKG <= 0)
                throw new InvalidEquipo("El peso debe ser mayor a 0.");
        }
    }
}
