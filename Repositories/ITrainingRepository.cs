using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitApi9K.Models.DTOs.TrainingDTOs;

namespace UnitApi9K.Repositories
{
    public interface ITrainingRepository
    {
        public  Task<TrainingSessionDTO> CreateAsync(CreateTrainingSessionDTO newTrainingSession);
    }
}