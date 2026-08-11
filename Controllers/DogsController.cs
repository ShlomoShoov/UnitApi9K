using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<ActionResult> Test()
        {
            return Ok("hello");
        }
    }
}