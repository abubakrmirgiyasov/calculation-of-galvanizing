using System;

namespace SZGC.Domain.Exceptions
{
    public class NeedUpdatePasswordException : Exception
    {
        public NeedUpdatePasswordException() { }

        public NeedUpdatePasswordException(string message)
            : base(message) { }
    }
}
