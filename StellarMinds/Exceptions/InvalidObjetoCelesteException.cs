using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Exceptions
{
    public class InvalidObjetoCelesteException : Exception
    {

        public InvalidObjetoCelesteException() { }
        public InvalidObjetoCelesteException(string message) : base(message) { }
        public InvalidObjetoCelesteException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
