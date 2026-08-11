using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitApi9K.Models.DTOs.TrainingDTOs
{
    public class TrainingSessionsDetailedDTO
    {
        public int Id { get; set; }
        public DateTime SessionDate { get; set; }

        public int DurationMinutes { get; set; }

        public string TrainingType { get; set; } = string.Empty;

        public int PerformanceScore { get; set; }

        public bool Passed { get; set; }

        public string Evaluator { get; set; } = string.Empty;
        public string DogName { get; set; } = string.Empty;

        public string DogSpecialty { get; set; } = string.Empty;

        public string? DogHandlerFullName { get; set; }
    }
}