using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnitApi9K.Models.DTOs.TrainingDTOs
{
    public class CreateTrainingSessionDTO
    {
        [Required]
        public DateTime SessionDate { get; set; }

        [Range(1, 300)]
        [Required]
        public int DurationMinutes { get; set; }

        [Required]
        [AllowedValues(["Obedience", "ScentDetection", "Agility", "FieldExercise", "Endurance"])]
        public string TrainingType { get; set; } = string.Empty;

        [Range(0, 100)]
        [Required]
        public int PerformanceScore { get; set; }


        [StringLength(100)]
        [Required]
        public string Evaluator { get; set; } = string.Empty;
        
        [Required]
        public int DogId { get; set; }
    }
}