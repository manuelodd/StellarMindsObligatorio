using Dominio.Exceptions;
using StellarMinds.Enums;
using StellarMinds.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class Camara : Equipo
    {

        public TipoSensor? TipoSensor { get; set; }
        public int Resolution { get; set; }
        public decimal PixelSize { get; set; }

        public Camara() { }


        public void Validar() 
        {
            if (string.IsNullOrEmpty(Marca))
                throw new InvalidEquipo("La marca no puede ser vacía.");
            if (string.IsNullOrEmpty(Modelo))
                throw new InvalidEquipo("El modelo no puede ser vacío.");
            if (CantDisp < 0)
                throw new InvalidEquipo("La cantidad disponible no puede ser negativa.");
            if (TipoSensor == null)
                throw new InvalidEquipo("Tiene que elegir un tipo de sensor.");
            if (Resolution <= 0)
                throw new InvalidEquipo("La resolución debe ser mayor a 0.");
            if (PixelSize <= 0)
                throw new InvalidEquipo("El tamaño del pixel debe ser mayor a 0.");
        }
    }
}
