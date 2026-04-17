using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Exceptions
{
    public class InvalidDirection : Exception
    {
        public InvalidDirection () { }
        public InvalidDirection(string message) : base(message){ }
        public InvalidDirection(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
