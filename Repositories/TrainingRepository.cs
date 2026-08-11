using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
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


        public async Task<IEnumerable<TrainingSessionsDetailedDTO>> GetTrainingSessionsAsync()
        {
            IQueryable< TrainingSessionsDetailedDTO> query = _context.TrainingSessions.Select(t=> new TrainingSessionsDetailedDTO
            {
                Id = t.Id,
                SessionDate = t.SessionDate,
                Evaluator = t.Evaluator,
                DurationMinutes = t.DurationMinutes,
                Passed = t.Passed,
                PerformanceScore = t.PerformanceScore,
                TrainingType = t.TrainingType,
                DogName = t.Dog.Name,
                DogSpecialty = t.Dog.Specialty,
                DogHandlerFullName = t.Dog.Handler  == null ? null : t.Dog.Handler.FullName
            });

            return await query.ToListAsync();
        }


        public async Task<TrainingSessionPageDTO<TrainingSessionPageItemDTO>> GetTrainingSessionPageAsync(int page, int pageSize)
        {
            int itemsCount = await _context.TrainingSessions.CountAsync();

            TrainingSessionPageDTO<TrainingSessionPageItemDTO> pageResult = new TrainingSessionPageDTO<TrainingSessionPageItemDTO>
            {
                ItemsCount = itemsCount,
                Page = page,
                PagesCount = (int)Math.Ceiling((double)itemsCount / pageSize)
            };

            int skip = (page -1 ) * pageSize;

            ICollection<TrainingSessionPageItemDTO> Items = await  _context.TrainingSessions
                                                                    .OrderByDescending(t=> t.SessionDate)
                                                                    .Skip(skip)
                                                                    .Take(pageSize)
                                                                    .Select(t=> new TrainingSessionPageItemDTO
                                                                    {
                                                                        Id  = t.Id,
                                                                        SessionDate = t.SessionDate,
                                                                        PerformanceScore = t.PerformanceScore,
                                                                        DogName = t.Dog.Name
                                                                    }).ToListAsync();
            pageResult.Items = Items;
            pageResult.PageSize = Items.Count;

            return pageResult;                                                         
            

        }
    }
}