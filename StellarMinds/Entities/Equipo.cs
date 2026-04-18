using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Entities
{
    public class Equipo
    {
        private static int _id = 0;


        public Equipo()
        {
            Id = _id++;
        }
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CantDisp {  get; set; }
    }
}
