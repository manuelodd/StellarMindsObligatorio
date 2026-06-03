using Dominio.Entities;
using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface IListarAuditoriasPrestamo
    {
        public List<AuditoriaPrestamoDTO> Execute();
    }
}
