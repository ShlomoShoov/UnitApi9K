using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitApi9K.Exceptions.DogsExceptions
{
    public class DateNotInPastException : Exception
    {
        public DateTime DateOfBirth { get; }

        public DateNotInPastException(DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
        }
    }
}