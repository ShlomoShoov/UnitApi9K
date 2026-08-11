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
        [HttpGet("detailed")]
        public async Task<ActionResult<IEnumerable<TrainingSessionsDetailedDTO>>> GetTrainingSessionsAsync()
        {
            return Ok(await _repository.GetTrainingSessionsAsync());
        }

        [HttpGet("paged")]
        public async Task<ActionResult<TrainingSessionPageDTO<TrainingSessionPageItemDTO>>> GetTrainingSessionPageAsync(int page = 1, int pageSize = 10)
        {
            if (!ValidPageParameters(page, pageSize))
            {
                return BadRequest();
            }
            return Ok(await _repository.GetTrainingSessionPageAsync(page, pageSize));
        }

        private static bool ValidPageParameters(int page , int pageSize)
        {
            return page >= 1 && pageSize >= 5 && pageSize <= 50;
        }


    }
}