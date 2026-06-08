using DTOs.DTOs;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface IAltaEquipo
    {
        public void Execute(EquipoDTO dto);
    }
}
