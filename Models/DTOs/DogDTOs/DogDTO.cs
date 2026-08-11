using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitApi9K.Models.DTOs.DogDTOs
{
    public class DogDTO
    {
        public int Id { get; set; }

   
        public string Name { get; set; } = string.Empty;


        public string Breed { get; set; } = string.Empty;


        public string MicrochipId { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }


        public string Specialty { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;


    }
}