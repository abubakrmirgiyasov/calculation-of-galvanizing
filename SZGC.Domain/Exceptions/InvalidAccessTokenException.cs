using System;

namespace SZGC.Domain.Exceptions
{
    public class InvalidAccessTokenException : Exception
    {
        public InvalidAccessTokenException() { }

        public InvalidAccessTokenException(string message) 
            : base(message) { }
    }
}
