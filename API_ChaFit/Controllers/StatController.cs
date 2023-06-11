using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Queries.Stat;
using Queries.Utils;
using Repository.StatRepository;

namespace API_ChaFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        private readonly iStatRepository _statRepository;
        private readonly iStatQueries _statQueries;
        private readonly iStatByUserExer _statUtil;

        public StatController(iStatRepository exerciseRepository, iStatQueries exerciseQueries, iStatByUserExer _stat)
        {
            _statRepository = exerciseRepository;
            _statQueries = exerciseQueries;
            _statUtil = _stat;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var result = await _statQueries.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _statQueries.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Stat stat)
        {
            var result = await _statRepository.Create(stat);
            return Ok(result);

        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Stat stat)
        {
            var result = await _statRepository.Update(stat);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _statRepository.Delete(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("{userId}/{exerciseId}")]
        public async Task<ActionResult> GetByUserExer([FromRoute] int userId, int exerciseId)
        {
            var result = await _statUtil.GetByUserExer(userId, exerciseId) ;

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
