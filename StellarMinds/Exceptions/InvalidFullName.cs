using StellarMinds.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Exceptions
{
    public class InvalidFullName : Exception
    {
        public InvalidFullName() { }
        public InvalidFullName(string message) : base(message) { }
        public InvalidFullName(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}