using System;

namespace SZGC.Domain.Exceptions
{
    public class ServerConnectionFailedException : Exception
    {
        public ServerConnectionFailedException() { }

        public ServerConnectionFailedException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
