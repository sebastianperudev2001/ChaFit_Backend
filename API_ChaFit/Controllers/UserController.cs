using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
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

        public class LoginModel 
        {
            public string email { get; set; }
            public string password { get; set; }


        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            // Validate loginModel
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Here you can perform your login verification logic
            // For simplicity, let's assume a hardcoded username and password
            string email = "sebas@gmail.com";
            string password = "123";

            if (login.email == email && login.password == password)
            {
                // Authentication successful
                // You can generate and return a JWT token or perform any other desired actions
                return Ok(new { message = "Authentication successful" });
            }
            else
            {
                // Authentication failed
                return Unauthorized(new { message = "Invalid username or password" });
            }
        }



    }
}
