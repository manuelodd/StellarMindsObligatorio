using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Exceptions
{
    public class InvalidEquipo : Exception
    {

        public InvalidEquipo() { }
        public InvalidEquipo(string message) : base(message) { }
        public InvalidEquipo(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
