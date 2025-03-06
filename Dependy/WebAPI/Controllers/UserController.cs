using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.Middlewares;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        private readonly ILogger<GlobalExceptionHandlingMw> _logger;

        public UserController(IUserRepository userRepository,ILogger<GlobalExceptionHandlingMw> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetUserById(string id)
        {
            _logger.LogError("No user found");
            return BadRequest("cghhsg");
            //var user = await _userRepository.GetUserByIdAsync(id);
            //if (user == null)
            //{
            //    _logger.LogError("No user found");
            //    throw new Exception("Noooooo Userrrrrrrrrrrrr");
            //    //return NotFound("User not found");
            //}
            //return Ok(user);

        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserDto createUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    msg="Podi"
                });

            var user = new User
            {
                name = createUserDto.Name,
                email = createUserDto.Email
            };

            await _userRepository.CreateUserAsync(user);

            var userDto = new UserDto
            {
                Name = user.name,
                Email = user.email
            };

            return Ok(user);
        }


    }
}
