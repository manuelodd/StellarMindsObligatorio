using Dominio.Exceptions;
using StellarMinds.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class Montura : Equipo
    {
        public TipoMontura? Tipo { get; set; }
        public decimal CargaKG { get; set; }
        public bool GoTo { get; set; }


        public void Validar()
        {
            if (string.IsNullOrEmpty(Marca))
                throw new InvalidEquipoException("La marca no puede ser vacía.");
            if (string.IsNullOrEmpty(Modelo))
                throw new InvalidEquipoException("El modelo no puede ser vacío.");
            if (CantDisp < 0)
                throw new InvalidEquipoException("La cantidad disponible no puede ser negativa.");
            if (Tipo == null)
                throw new InvalidEquipoException("Tiene que elegir un tipo de montura.");
            if (CargaKG <= 0)
                throw new InvalidEquipoException("La carga debe ser mayor a 0.");
        }
    }
}
