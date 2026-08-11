using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnitApi9K.Models.DTOs.TrainingDTOs
{
    public class TrainingSessionDTO
    {
        public int Id { get; set; }
        public DateTime SessionDate { get; set; }

        [Range(1, 300)]
        public int DurationMinutes { get; set; }

        [AllowedValues(["Obedience", "ScentDetection", "Agility", "FieldExercise", "Endurance"])]
        public string TrainingType { get; set; } = string.Empty;

        [Range(0, 100)]
        public int PerformanceScore { get; set; }

        public bool Passed { get; set; }

        [StringLength(100)]
        public string Evaluator { get; set; } = string.Empty;
        public int DogId { get; set; }
    }
}