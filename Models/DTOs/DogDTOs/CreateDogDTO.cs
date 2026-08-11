using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnitApi9K.Models.DTOs.DogDTOs
{
    public class CreateDogDTO
    {
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(50)]
        public string Breed { get; set; } = string.Empty;

        [StringLength(15)]
        public string MicrochipId { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        [AllowedValues(["ExplosiveDetection", "NarcoticsDetection", "Tracking", "Attack", "Search"])]
        public string Specialty { get; set; } = string.Empty;

        [AllowedValues(["Active", "InTraining", "Retired",null])]
        public string? Status { get; set; }




    }
}