using System;

namespace SZGC.Domain.Exceptions
{
    public class OutOfRangeSessionsException : Exception
    {
        public OutOfRangeSessionsException() { }

        public OutOfRangeSessionsException(string message) 
            : base(message) { }
    }
}
