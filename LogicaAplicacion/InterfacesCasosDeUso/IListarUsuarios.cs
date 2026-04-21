using DTOs;
using LogicaAccesoDatos.RepositorioMemoria;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface IListarUsuarios
    {
        public List<UsuarioDTO> ListarUsuarios();

    }
}
