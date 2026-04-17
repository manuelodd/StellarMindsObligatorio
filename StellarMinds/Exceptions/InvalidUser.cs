using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Exceptions
{
    public class InvalidUser : Exception
    {
        public InvalidUser() { }
        public InvalidUser(string message) : base(message) { }
        public InvalidUser(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
