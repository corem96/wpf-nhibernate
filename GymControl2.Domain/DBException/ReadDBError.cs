using System;

namespace GymControl2.Domain.DBException
{
    public class ReadDBError : Exception
    {
        public ReadDBError() { }

        public ReadDBError(string message) : base(message) { }

        public ReadDBError(string message, Exception inner)
        : base(message, inner)
        { }
    }
}
