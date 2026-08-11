using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitApi9K.Exceptions.DogsExceptions
{
    public class DogNotFoundException : Exception
    {
        public int Id { get; set; }
        public DogNotFoundException(int id) : base()
        {
            Id = id;
        }
    }
}