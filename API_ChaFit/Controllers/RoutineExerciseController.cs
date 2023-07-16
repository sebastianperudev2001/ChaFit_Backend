using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Queries.Muscle;
using Queries.RoutineExercise;
using Queries.Utils;
using Repository.MuscleRepository;
using Repository.RoutineExerciseRepository;

namespace API_ChaFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutineExerciseController : ControllerBase
    {
        private readonly iRoutineExerciseRepository _reRepository;
        private readonly iRoutineExerciseQueries _reQueries;
        private readonly iExeRouteByDate _reDate;
        private readonly iExercisesByRoutine _exRou;

        public RoutineExerciseController(iRoutineExerciseRepository reRepository, iRoutineExerciseQueries reQueries, iExeRouteByDate reDate, iExercisesByRoutine exRou)
        {
            _reRepository = reRepository;
            _reQueries = reQueries;
            _reDate = reDate;
            _exRou = exRou;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var result = await _reQueries.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _reQueries.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] RoutineExercise re)
        {
            var result = await _reRepository.Create(re);
            return Ok(result);

        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] RoutineExercise re)
        {
            var result = await _reRepository.Update(re);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _reRepository.Delete(id);
            return Ok(result);
        }

        /*
        [HttpGet]
        [Route("workout/{date}")]
        public async Task<ActionResult> GetByDate([FromRoute] DateTime date)
        {
            var result = await _reDate.GetByDate(date);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        */

        [HttpGet]
        [Route("exercises/{routine_id}")]
        public async Task<ActionResult> GetByRoutineId([FromRoute] int routine_id)
        {
            var result = await _exRou.GetByRoutineId(routine_id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }





    }
}
