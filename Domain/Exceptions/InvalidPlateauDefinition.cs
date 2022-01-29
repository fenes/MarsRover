using System;

namespace Domain.Exceptions
{
    public class InvalidPlateauDefinition : Exception
    {
        public InvalidPlateauDefinition()
        {
        }

        public InvalidPlateauDefinition(string message)
            : base(message)
        {
        }

        public InvalidPlateauDefinition(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}