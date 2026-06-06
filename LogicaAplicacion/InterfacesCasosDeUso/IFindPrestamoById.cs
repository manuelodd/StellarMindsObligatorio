using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface IFindPrestamoById
    {
        public PrestamoDTO Execute(int id);
    }
}
