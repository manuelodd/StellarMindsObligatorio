using StellarMinds.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class Equipo : IValidable
    {
        private static int _id = 0;


        public Equipo()
        {

        }
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CantDisp {  get; set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
