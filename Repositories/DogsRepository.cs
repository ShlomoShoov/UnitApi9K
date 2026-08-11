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