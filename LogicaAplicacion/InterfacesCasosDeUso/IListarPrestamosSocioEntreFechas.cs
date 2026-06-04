using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public  interface IListarPrestamosSocioEntreFechas
    {
        public List<PrestamoDTO> Execute(int socioId, int mes, int anio);
    }
}
