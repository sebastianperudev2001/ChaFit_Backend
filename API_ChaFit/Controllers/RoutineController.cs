using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Model;
using Queries.Routine;
using Queries.Utils;
using Repository.RoutineRepository;

namespace API_ChaFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutineController : ControllerBase
    {
        private readonly iRoutineRepository _routineRepository;
        private readonly iRoutineQueries _routineQueries;
        private readonly iRoutineByUser _routineByUser;

        public RoutineController(iRoutineRepository exerciseRepository, iRoutineQueries exerciseQueries, iRoutineByUser rou)
        {
            _routineRepository = exerciseRepository;
            _routineQueries = exerciseQueries;
            _routineByUser = rou;

        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var result = await _routineQueries.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _routineQueries.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Routine routine)
        {
            var result = await _routineRepository.Create(routine);
            return Ok(result);

        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Routine routine)
        {
            var result = await _routineRepository.Update(routine);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _routineRepository.Delete(id);
            return Ok(result);
        }
          
        [HttpGet]
        [Route("user/{user_id}")]
        public async Task<ActionResult> GetByName([FromRoute] int user_id)
        {
            var result = await _routineByUser.GetByName(user_id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
          


    }
}
