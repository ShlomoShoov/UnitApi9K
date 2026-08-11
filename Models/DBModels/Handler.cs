using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UnitApi9K.Models.DBModels
{
    [Index(nameof(PersonalNumber),IsUnique = true)]
    public class Handler
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [StringLength(10)]
        public string PersonalNumber { get; set; } = string.Empty;

        [StringLength(30)]
        public string Rank { get; set; } = string.Empty;
        [Range(0,40)]
        public int YearsOfExperience { get; set; }

        [StringLength(100)]
        public string BaseAssigned { get; set; } = string.Empty;

        public ICollection<Dog> Dogs { get; set; } = [];
    }
}