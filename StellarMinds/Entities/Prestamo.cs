using StellarMinds.Enums;
using StellarMinds.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class Prestamo : IValidable
    {
        private static int _id = 0;
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }
        public EstadoPrestamo Estado {  get; set; }

        public Prestamo() 
        { 
            
            
        }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
