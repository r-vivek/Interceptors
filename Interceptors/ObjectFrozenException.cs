using System;

namespace Interceptors
{
    internal class ObjectFrozenException : Exception
    {
        public ObjectFrozenException(string message) : base(message)
        {
        }
    }
}
