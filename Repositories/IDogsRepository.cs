using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitApi9K.Models.DTOs.DogDTOs;

namespace UnitApi9K.Repositories
{
    public interface IDogsRepository
    {
        public  Task<DogDTO> GetByIdAsync(int id);
        public  Task<DogDTO> CreateDogAsync(CreateDogDTO newDog);
    }
}