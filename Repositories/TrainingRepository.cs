using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitApi9K.DAL;
using UnitApi9K.Exceptions.DogsExceptions;
using UnitApi9K.Exceptions.TrainingSessionsExceptions;
using UnitApi9K.Models;
using UnitApi9K.Models.DBModels;
using UnitApi9K.Models.DTOs.TrainingDTOs;

namespace UnitApi9K.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private UnitManagementDbContext _context;
        public TrainingRepository(UnitManagementDbContext context)
        {
            _context = context;
        }

        public async Task<TrainingSessionDTO> CreateAsync(CreateTrainingSessionDTO newTrainingSession)
        {
            Dog? trainingDog = _context.Dogs.FirstOrDefault(d => d.Id == newTrainingSession.DogId);

            if (trainingDog == null)
            {
                throw new DogNotFoundException(newTrainingSession.DogId);
            }

            bool trainingDateOnFuture = newTrainingSession.SessionDate >= DateTime.Now;

            if (trainingDateOnFuture)
            {
                throw new TrainingInFutureDateException(newTrainingSession.SessionDate);
            }

            bool dogNotInPossibleStatus = trainingDog.Status == "Retired";

            if (dogNotInPossibleStatus)
            {
                throw new DogNotInPossibleStatusException(trainingDog.Status);
            }

            TrainingSession createdTrainingSession = new TrainingSession
            {
                SessionDate = newTrainingSession.SessionDate,
                DurationMinutes = newTrainingSession.DurationMinutes,
                PerformanceScore = newTrainingSession.PerformanceScore,
                TrainingType = newTrainingSession.TrainingType,
                Passed = newTrainingSession.PerformanceScore >= 75,
                DogId = newTrainingSession.DogId,
                Evaluator = newTrainingSession.Evaluator
            };

            _context.TrainingSessions.Add(createdTrainingSession);
            await _context.SaveChangesAsync();

            return new TrainingSessionDTO
            {
                
                SessionDate = createdTrainingSession.SessionDate,
                DurationMinutes = createdTrainingSession.DurationMinutes,
                PerformanceScore = createdTrainingSession.PerformanceScore,
                TrainingType = createdTrainingSession.TrainingType,
                Passed = createdTrainingSession.PerformanceScore >= 75,
                DogId = createdTrainingSession.DogId,
                Evaluator = createdTrainingSession.Evaluator,
                Id = createdTrainingSession.Id
            };



        }
    }
}