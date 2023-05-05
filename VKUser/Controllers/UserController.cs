using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VKUser.Database.Repository;

namespace VKUser.Controllers
{
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return BadRequest(401);
            }

            if (id is > 0)
            {
                var user = await _userRepository.GetAsync(id.Value);

                if (user != null)
                {
                    return Ok(user);
                }

                return NotFound();
            }
            else
            {
                return BadRequest(400);
            }
        }
    }
}