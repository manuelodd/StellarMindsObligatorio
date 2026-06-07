using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Exceptions
{
    public class InvalidEquipoException : Exception
    {

        public InvalidEquipoException() { }
        public InvalidEquipoException(string message) : base(message) { }
        public InvalidEquipoException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
