using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface ILoginUsuario
    {
        public Usuario Execute(string username, string password);

    }
}
