using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Exceptions
{
    public class InvalidPrestamoException : Exception
    {
        
            public InvalidPrestamoException() { }
            public InvalidPrestamoException(string message) : base(message) { }
            public InvalidPrestamoException(string? message, Exception? innerException) : base(message, innerException)
            {
            }
        }
    }

