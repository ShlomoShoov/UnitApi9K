using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitApi9K.Exceptions.DogsExceptions
{
    public class MicrochipIdExistsException : Exception
    {
        public string MicrochipId { get;  }
        public MicrochipIdExistsException(string microchipId) : base()
        {
            MicrochipId = microchipId;
        }
    }
}