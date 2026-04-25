using DTOs.DTOs;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface IAltaUsuario
    {
        public void Execute(UsuarioDTO unUsuario);

    }
}
