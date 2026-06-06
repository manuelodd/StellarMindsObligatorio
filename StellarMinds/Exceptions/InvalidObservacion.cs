using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Exceptions
{
    public class InvalidObservacion : Exception
    {

        public InvalidObservacion() { }
        public InvalidObservacion(string message) : base(message) { }
        public InvalidObservacion(string? message, Exception? innerException) : base(message, innerException) { }
    }

}
