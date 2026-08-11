using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<TrainingSessionDTO>> CreateAsync(CreateTrainingSessionDTO newTrainingSession)
        {
            return (await _repository.CreateAsync(newTrainingSession));
        }
    }
}