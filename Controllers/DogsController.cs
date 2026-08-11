using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnitApi9K.Exceptions.DogsExceptions;
using UnitApi9K.Models.DTOs.DogDTOs;
using UnitApi9K.Repositories;

namespace UnitApi9K.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DogsController : ControllerBase
    {
        private IDogsRepository _repository;
        public DogsController(IDogsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DogDTO>> GetById(int id)
        {
            try
            {
                return Ok(await _repository.GetByIdAsync(id));
            }
            catch(DogNotFoundException ex)
            {
                return NotFound($"Id Not Found: {ex.Id}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<DogDTO>> CreateDog(CreateDogDTO newDog)
        {
            DogDTO createdDog;
            try
            {
                createdDog = await _repository.CreateDogAsync(newDog);
                return CreatedAtAction(nameof(GetById), new {id= createdDog.Id}, createdDog);
            }
            catch (DateNotInPastException ex)
            {
                return BadRequest($"Date of birth must be in the past, given: {ex.DateOfBirth}");
            }

            catch(MicrochipIdExistsException ex)
            {
                return BadRequest($"MicrochipId {ex.MicrochipId} - already exists ");
            }

            
        }

        // queries
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<SearchDogDTO>>> SearchDogsAsync(string? specialty, string? status)
        {
            if (!IsValidSearchParameters(specialty, status))
            {
                return BadRequest();
            }
            return Ok(await _repository.SearchDogsAsync(specialty, status));
        }
        [HttpGet("with-handler")]
        public async Task<ActionResult<IEnumerable<DogWithHandlerDTO>>> GetDogsWithHandlerAsync()
        {
            return Ok(await _repository.GetDogsWithHandlerAsync());
        }

        [HttpGet("performance-summary")]
        public async Task<ActionResult<IEnumerable<DogWithPerformanceSummaryDTO>>> GetDogWithPerformancesAsync()
        {
            return Ok(await _repository.GetDogWithPerformancesAsync() );
        }

        private static bool IsValidSearchParameters(string? specialty, string? status)

        {
            List<string> allowedSpecialty =  ["ExplosiveDetection", "NarcoticsDetection", "Tracking", "Attack", "Search"];
            bool specialtyCorrect = string.IsNullOrEmpty(specialty) || allowedSpecialty.Contains(specialty);
            List<string> allowedStatuses = ["Active", "InTraining", "Retired"];
            bool statusCorrect = string.IsNullOrEmpty(status) || allowedStatuses.Contains(status);

            return specialtyCorrect && statusCorrect;
        }


    }
}