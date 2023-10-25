using System;

namespace SZGC.Domain.Exceptions
{
    public class InvalidRefreshTokenException : Exception
    {
        public InvalidRefreshTokenException() { }

        public InvalidRefreshTokenException(string message)
            : base(message) { }
    }
}
