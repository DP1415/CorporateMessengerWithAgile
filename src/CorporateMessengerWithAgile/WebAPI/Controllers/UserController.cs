using Domain.Entity;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers(CancellationToken cancellationToken = default)
        {
            var users = await _userRepository.GetAllAsync(cancellationToken);
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] string userName, CancellationToken cancellationToken = default)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                name = userName
            };

            await _userRepository.AddAsync(user, cancellationToken);
            return CreatedAtAction(nameof(GetAllUsers), new { id = user.Id }, user);
        }
    }
}