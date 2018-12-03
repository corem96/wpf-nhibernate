using System;

namespace GymControl2.Domain.DBException
{
    public class DeleteDBException : Exception
    {
        public DeleteDBException() { }

        public DeleteDBException(string message) : base(message) { }

        public DeleteDBException(string message, Exception inner)
        : base(message, inner)
        { }
    }
}
