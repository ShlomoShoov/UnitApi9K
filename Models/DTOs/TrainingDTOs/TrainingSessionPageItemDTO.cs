using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitApi9K.Models.DTOs.TrainingDTOs
{
    public class TrainingSessionPageItemDTO
    {
        public int Id { get; set; }
        public DateTime SessionDate { get; set; }
        public int PerformanceScore { get; set; }
        public string DogName { get; set; } = string.Empty;

    }
}