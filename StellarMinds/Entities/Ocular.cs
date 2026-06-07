using Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class Ocular : Equipo
    {
        public decimal Diametro { get; set; }
        public decimal GradosVision { get; set; }


        public void Validar()
        {
            if (string.IsNullOrEmpty(Marca))
                throw new InvalidEquipoException("La marca no puede ser vacía.");
            if (string.IsNullOrEmpty(Modelo))
                throw new InvalidEquipoException("El modelo no puede ser vacío.");
            if (CantDisp < 0)
                throw new InvalidEquipoException("La cantidad disponible no puede ser negativa.");
            if (Diametro <= 0)
                throw new InvalidEquipoException("El diámetro debe ser mayor a 0.");
            if (GradosVision <= 0)
                throw new InvalidEquipoException("Los grados de visión deben ser mayores a 0.");
        }
    }
}
