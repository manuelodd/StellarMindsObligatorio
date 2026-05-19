using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class EquipoDTO
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CantDisp { get; set; }

        //evaluar el tipo del objeto (tele, montu, cam, ocu)
        public string Tipo { get; set; }
    }
}
