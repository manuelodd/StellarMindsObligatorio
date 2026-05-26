using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Exceptions
{
    public class InvalidPrestamo : Exception
    {
        
            public InvalidPrestamo() { }
            public InvalidPrestamo(string message) : base(message) { }
            public InvalidPrestamo(string? message, Exception? innerException) : base(message, innerException)
            {
            }
        }
    }

