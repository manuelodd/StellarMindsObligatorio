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
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }
        public EstadoPrestamo Estado {  get; set; }
        public int? TelescopioID { get; set; } = null;
        public int? MonturaID { get; set; } = null;
        public int? CamaraID { get; set; } = null;
        public int? OcularID { get; set; } = null;

        public Prestamo() 
        { 
            
            
        }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
