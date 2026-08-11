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
    public class HandlersController : ControllerBase
    {
        private IHandlersRepository _repository;
        public HandlersController(IHandlersRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHandler(int id)
        {
            bool deleted  = await _repository.DeleteHandlerAsync(id);
            if (deleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}