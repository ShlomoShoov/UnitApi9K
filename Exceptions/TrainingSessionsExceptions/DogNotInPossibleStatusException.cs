using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitApi9K.Exceptions.TrainingSessionsExceptions
{
    public class DogNotInPossibleStatusException : Exception
    {
        public string DogStatus { get; }

        public DogNotInPossibleStatusException(string dogStatus) : base()
        {
            DogStatus = dogStatus;
        }
    }
}