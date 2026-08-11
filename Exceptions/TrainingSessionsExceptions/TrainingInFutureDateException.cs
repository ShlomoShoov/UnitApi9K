using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitApi9K.Exceptions.TrainingSessionsExceptions
{
    public class TrainingInFutureDateException : Exception
    {
        public DateTime TrainingDate { get; set; }
        public TrainingInFutureDateException(DateTime trainingDate):base()
        {
             TrainingDate = trainingDate;
        }
    }
}