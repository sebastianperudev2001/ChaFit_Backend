using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Queries.Muscle;
using Repository.MuscleRepository;

namespace API_ChaFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuscleController : ControllerBase
    {

        private readonly iMuscleRepository _muscleRepository;
        private readonly iMuscleQueries _muscleQueries;

        public MuscleController(iMuscleRepository muscleRepository, iMuscleQueries muscleQueries)
        {
            _muscleRepository = muscleRepository;
            _muscleQueries = muscleQueries;

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var result = await _muscleQueries.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _muscleQueries.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Muscle muscle)
        {
            var result = await _muscleRepository.Create(muscle);
            return Ok(result);

        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Muscle muscle)
        {
            var result = await _muscleRepository.Update(muscle);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _muscleRepository.Delete(id);
            return Ok(result);
        }

    }
}
