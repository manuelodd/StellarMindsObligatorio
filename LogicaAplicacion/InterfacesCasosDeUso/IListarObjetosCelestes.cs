using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface IListarObjetosCelestes
    {
        public IEnumerable<ObjetoCelesteDTO> Execute();
    }
}
