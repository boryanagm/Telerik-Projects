using LayeredArchitecture.Models;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;

namespace LayeredArchitecture.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly List<User> users = new List<User>
        {
            new User
            {
                Id = 1,
                Name = "Bruce Banner",
                Email = "bruce@avengers.com"
            },
            new User
            {
                Id = 2,
                Name = "Tony Stark",
                Email = "tony@avengers.com"
            },
        };

        [HttpGet("")]
        public IActionResult Get()
        {
            return this.Ok(this.users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = this.users.FirstOrDefault(user => user.Id == id);

            if (user == null)
            {
                return this.NotFound();
            }

            return this.Ok(user);
        }

        [HttpPost("")]
        public IActionResult Post([FromBody] User model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            //Does NOT work => controllers are resolved on each request - demo purposes
            this.users.Add(model);

            return this.Created("post", model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User model)
        {
            if (id < 1 || model == null)
                return this.BadRequest();

            var user = this.users.FirstOrDefault(user => user.Id == id);

            user.Name = model.Name;
            user.Email = model.Email;

            return this.Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = this.users.FirstOrDefault(user => user.Id == id);

            if (user == null)
                return this.NotFound();

            this.users.Remove(user);

            return this.NoContent();
        }
    }
}
