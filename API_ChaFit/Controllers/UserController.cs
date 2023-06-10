using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Queries.User;
using Repository.UserRepository;

namespace API_ChaFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly iUserRepository _userRepository;
        private readonly iUserQueries _userQueries;

        public UserController(iUserRepository userRepository, iUserQueries userQueries)
        {
            _userRepository = userRepository;
            _userQueries = userQueries;

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var result = await _userQueries.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _userQueries.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] User user)
        {
            var result = await _userRepository.Create(user);
            return Ok(result);

        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] User user)
        {
            var result = await _userRepository.Update(user);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _userRepository.Delete(id);
            return Ok(result);
        }



    }
}
