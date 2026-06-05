using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface IListarSociosByTelescopio
    {
        public IEnumerable<UsuarioDTO> Execute(int telescopioId);
    }
}
