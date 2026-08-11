using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitApi9K.Models.DBModels;

namespace UnitApi9K.Models
{
    [Index(nameof(MicrochipId), IsUnique = true)]
    public class Dog
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(50)]
        public string Breed { get; set; } = string.Empty;

        [StringLength(15)]
        public string MicrochipId { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        [AllowedValues(["ExplosiveDetection", "NarcoticsDetection", "Tracking", "Attack", "Search"])]
        public string Specialty { get; set; } = string.Empty;


        [AllowedValues(["Active", "InTraining", "Retired"])]
        public string Status { get; set; } = string.Empty;
        public static string DefaultStatus = "InTraining";

        public int? HandlerId { get; set; }
        public Handler? Handler { get; set; } 

        public ICollection<TrainingSession> TrainingSessions = [];

    }
}