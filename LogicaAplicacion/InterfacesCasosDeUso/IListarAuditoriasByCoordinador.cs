using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface IListarAuditoriasByCoordinador
    {
        public IEnumerable<AuditoriaPrestamoDTO> Execute(int coordinadorId);
    }
}
