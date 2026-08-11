using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnitApi9K.Exceptions.DogsExceptions;
using UnitApi9K.Exceptions.TrainingSessionsExceptions;
using UnitApi9K.Models.DTOs.TrainingDTOs;
using UnitApi9K.Repositories;

namespace UnitApi9K.Controllers
{
    [ApiController]
    [Route("api/[controller]-sessions")]
    public class TrainingController : ControllerBase
    {
        private ITrainingRepository _repository;
        public TrainingController(ITrainingRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateTrainingSessionDTO newTrainingSession)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created ,await _repository.CreateAsync(newTrainingSession));
            }
            catch (DogNotFoundException)
            {
                return NotFound();
            }
            catch(DogNotInPossibleStatusException ex)
            {
                return BadRequest();
            }
            catch (TrainingInFutureDateException)
            {
                return BadRequest();
            }
        
          
        }
    }
}