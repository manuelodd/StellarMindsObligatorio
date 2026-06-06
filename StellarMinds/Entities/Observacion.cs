using Dominio.Entities;
using Dominio.Exceptions;
using StellarMinds.Enums;
using StellarMinds.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class Observacion : IValidable
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int PrestamoId { get; set; }
        public int ObjetoCelesteId { get; set; }
        public Prestamo Prestamo { get; set; }
        public ObjetoCeleste ObjetoCeleste { get; set; }
        public string Indicador { get; set; } = string.Empty;
        public string Detalle { get; set; } = string.Empty;



        public void Validar()
        {
            if (Fecha < DateTime.Today)
                throw new InvalidObservacion("La fecha debe ser válida");
            if (PrestamoId == 0)
                throw new InvalidObservacion("Prestamo no válido.");
            if (ObjetoCelesteId == 0)
                throw new InvalidObservacion("Objeto celeste no válido.");
            if (Prestamo == null)
                throw new InvalidObservacion("Debe existir un préstamo.");
            if (ObjetoCeleste == null)
                throw new InvalidObservacion("Debe existir un objeto celeste.");
            /*
            if (string.IsNullOrWhiteSpace(Indicador))
                throw new InvalidObservacion("Indicador no puede ser vacío.");
            if (string.IsNullOrWhiteSpace(Detalle))
                throw new InvalidObservacion("Detalle no puede ser vacío.");
            */
            if (Prestamo.Estado != EstadoPrestamo.EN_PRESTAMO)
                throw new InvalidObservacion("El préstamo no se encuentra activo.");
            if (Fecha < Prestamo.FechaInicio || Fecha > Prestamo.FechaFin)
                throw new InvalidObservacion("La fecha de observación está afuera del período del préstamo.");
        }
    }
}

