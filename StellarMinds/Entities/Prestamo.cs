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
        public int SocioId { get; set; }
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
            if (Socio == null)
                throw new InvalidPrestamoException("Debe elegir un socio.");
            if (Camara == null && Ocular == null)
                throw new InvalidPrestamoException("El préstamo debe incluir una cámara u ocular.");
            if (Telescopio == null)
                throw new InvalidPrestamoException("Debe elegir un telescopio.");
            if (Montura == null)
                throw new InvalidPrestamoException("Debe elegir una montura.");
            if (Montura.CargaKG < Telescopio.PesoKG)
                throw new InvalidPrestamoException("El peso del telescopio excede la capacidad de la montura.");
            if (FechaInicio > FechaFin)
                throw new InvalidPrestamoException("La fecha de inicio no puede ser mayor a la de fin.");
            if (Camara != null && Montura.Tipo != TipoMontura.Ecuatorial && Montura.Tipo != TipoMontura.Hibrida)
                throw new InvalidPrestamoException("Para astrofotografía la montura debe ser ecuatorial o híbrida.");
        }
    }
}