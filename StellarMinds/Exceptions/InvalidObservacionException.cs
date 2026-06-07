using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Exceptions
{
    public class InvalidObservacionException : Exception
    {

        public InvalidObservacionException() { }
        public InvalidObservacionException(string message) : base(message) { }
        public InvalidObservacionException(string? message, Exception? innerException) : base(message, innerException) { }
    }

}
