using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Exceptions
{
        public class InvalidDirectionException : Exception
        {
            public InvalidDirectionException() { }
            public InvalidDirectionException(string message) : base(message) { }
            public InvalidDirectionException(string? message, Exception? innerException) : base(message, innerException)
            {
            }
        }
    }

