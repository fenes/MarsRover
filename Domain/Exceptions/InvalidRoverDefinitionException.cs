using System;

namespace Domain.Exceptions
{
    public class InvalidRoverDefinitionException : Exception
    {
        public InvalidRoverDefinitionException()
        {
        }

        public InvalidRoverDefinitionException(string message)
            : base(message)
        {
        }

        public InvalidRoverDefinitionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}