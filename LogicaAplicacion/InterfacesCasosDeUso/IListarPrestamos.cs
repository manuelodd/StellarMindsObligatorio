using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface IListarPrestamos
    {
        public List<PrestamoDTO> Execute();
    }
}
