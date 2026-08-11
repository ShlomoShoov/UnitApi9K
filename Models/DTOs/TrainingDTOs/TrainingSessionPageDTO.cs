using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitApi9K.Models.DTOs.TrainingDTOs
{
    public class TrainingSessionPageDTO<T>
    {
        public ICollection<T> Items { get; set; } = [];
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int PagesCount { get; set; }
        public int ItemsCount { get; set; }
    }
}