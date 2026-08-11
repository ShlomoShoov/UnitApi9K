using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitApi9K.DAL;
using UnitApi9K.Exceptions.DogsExceptions;
using UnitApi9K.Models;
using UnitApi9K.Models.DTOs.DogDTOs;

namespace UnitApi9K.Repositories
{
    public class DogsRepository : IDogsRepository
    {
        private UnitManagementDbContext _context;
        public DogsRepository(UnitManagementDbContext context)
        {
            _context = context;
        }

        public async Task<DogDTO> CreateDogAsync(CreateDogDTO newDog)
        {
            bool microchipIdExists = await _context.Dogs.AnyAsync(d => d.MicrochipId == newDog.MicrochipId);

            if (microchipIdExists)
            {
                throw new MicrochipIdExistsException(newDog.MicrochipId);
            }

            bool dateOfBirthNotInPast = newDog.DateOfBirth >= DateTime.Now;
    

            if (dateOfBirthNotInPast)
            {
                throw new DateNotInPastException(newDog.DateOfBirth);
            }

            Dog createdDog = new Dog
            {
                Name = newDog.Name,
                Breed = newDog.Name,
                DateOfBirth = newDog.DateOfBirth,
                MicrochipId = newDog.MicrochipId,
                Specialty = newDog.Specialty,
                Status = newDog.Status == null ? Dog.DefaultStatus : newDog.Status
            };

            _context.Dogs.Add(createdDog);
            await _context.SaveChangesAsync();

            return DtoizeDog(createdDog);
        }

        public async Task<DogDTO> GetByIdAsync(int id)
        {
            Dog? dog = _context.Dogs.FirstOrDefault(d=> d.Id == id);

            if (dog == null)
            {
                throw new DogNotFoundException(id);
            }
            return DtoizeDog(dog);
        }



        // first query

        public async Task<IEnumerable<SearchDogDTO>> SearchDogsAsync(string? specialty, string? status)
        {
            IQueryable<Dog> query = _context.Dogs;

            if (!string.IsNullOrEmpty(specialty))
            {
                query = query.Where(d=> d.Specialty == specialty);
            }

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(d => d.Status == status);
            }

            return await query.Select(d=> new SearchDogDTO
            {
                Id = d.Id,
                Name = d.Name,
                Breed = d.Breed,
                Specialty = d.Specialty,
                Status = d.Status
            }).ToListAsync();
        }

        public async Task<IEnumerable<DogWithHandlerDTO>> GetDogsWithHandlerAsync()
        {
            IQueryable<DogWithHandlerDTO> query = _context.Dogs.Select(d=> new DogWithHandlerDTO
            {
                Id = d.Id,
                Name = d.Name,
                Breed = d.Breed,
                Specialty = d.Specialty,
                Status = d.Status,
                HandlerFullName = d.Handler == null ? null : d.Handler.FullName,
                HandlerRank = d.Handler == null ? null : d.Handler.Rank
            });

            return await query.ToListAsync();
        }


        public async Task<IEnumerable<DogWithPerformanceSummaryDTO>> GetDogWithPerformancesAsync()
        {
            IQueryable< DogWithPerformanceSummaryDTO> query = _context.Dogs.Select(d=> new DogWithPerformanceSummaryDTO
            {
                Id = d.Id,
                Name = d.Name,
                Specialty = d.Specialty,
                TrainingSessionCount = d.TrainingSessions.Count,
                ScoreAverage = d.TrainingSessions.Average(t=> t.PerformanceScore)
            });
            return await query.ToListAsync();
        }




        private static DogDTO DtoizeDog(Dog dog)
        {

            return new DogDTO
            {
                Id = dog.Id,
                Name = dog.Name,
                Breed = dog.Name,
                DateOfBirth = dog.DateOfBirth,
                MicrochipId = dog.MicrochipId,
                Specialty = dog.Specialty,
                Status = dog.Status
            };
        }

    }
}