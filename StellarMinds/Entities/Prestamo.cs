using Dominio.Exceptions;
using StellarMinds.Enums;
using StellarMinds.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class Prestamo : IValidable
    {
        public int Id { get; set; }
        public Usuario Socio { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public EstadoPrestamo Estado { get; set; }
        public Telescopio Telescopio { get; set; }
        public Montura Montura { get; set; }
        public Camara? Camara { get; set; } = null;
        public Ocular? Ocular { get; set; } = null;

        public Prestamo()
        {


        }

        public void Validar()
        {
            if (Camara == null && Ocular == null)
            {
                throw new InvalidPrestamo("El préstamo debe incluir una cámara u ocular");
            }

            if (Montura.CargaKG < Telescopio.PesoKG)
            {
                throw new InvalidPrestamo("El peso del telescopio excede la capacidad de la montura");
            }
        }
    }
}