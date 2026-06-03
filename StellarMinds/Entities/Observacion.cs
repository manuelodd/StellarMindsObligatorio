using Dominio.Entities;
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
        public string Indicador { get; set; }
        public string Detalle { get; set; }



        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
