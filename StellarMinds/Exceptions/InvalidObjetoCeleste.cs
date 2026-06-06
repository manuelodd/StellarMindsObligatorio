using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Exceptions
{
    public class InvalidObjetoCeleste : Exception
    {

        public InvalidObjetoCeleste() { }
        public InvalidObjetoCeleste(string message) : base(message) { }
        public InvalidObjetoCeleste(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
