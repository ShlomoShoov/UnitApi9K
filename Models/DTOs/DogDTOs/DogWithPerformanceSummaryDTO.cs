using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitApi9K.Models.DTOs.DogDTOs
{
    public class DogWithPerformanceSummaryDTO
    {
        public int Id { get; set; }


        public string Name { get; set; } = string.Empty;


        public string Specialty { get; set; } = string.Empty;

        public int TrainingSessionCount { get; set; }
        public double? ScoreAverage { get; set; }
    }
}