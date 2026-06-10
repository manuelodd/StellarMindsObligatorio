using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface IListarSocios
    {
        public IEnumerable<UsuarioDTO> Execute();
    }
}
