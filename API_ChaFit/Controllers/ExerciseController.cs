using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Queries.Exercise;
using Repository.ExerciseRepository;

namespace API_ChaFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly iExerciseRepository _exerciseRepository;
        private readonly iExerciseQueries _exerciseQueries;

        public ExerciseController(iExerciseRepository exerciseRepository, iExerciseQueries exerciseQueries)
        {
            _exerciseRepository = exerciseRepository;
            _exerciseQueries = exerciseQueries;

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var result = await _exerciseQueries.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _exerciseQueries.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Exercise exercise)
        {
            var result = await _exerciseRepository.Create(exercise);
            return Ok(result);

        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Exercise exercise)
        {
            var result = await _exerciseRepository.Update(exercise);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _exerciseRepository.Delete(id);
            return Ok(result);
        }

    }
}
