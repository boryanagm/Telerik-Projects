using ASPNetCoreOverview.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreOverview.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UserController : ControllerBase
    {
        private readonly List<User> users = new List<User>
        {
            new User
            {
                Id = 1,
                Name = "Stamat",
                Email = "stam@gmail.com"
            },
            new User
            {
                Id = 2,
                Name = "Begonia",
                Email = "rosna.kitka@abv.bg"
            },
        };

        //[HttpGet("")]
        //public IActionResult Get()
        //{
        //    return this.Ok(this.users);
        //}

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = this.users.FirstOrDefault(u => u.Id == id);

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

            this.users.Add(model);

            return this.Created("post", model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User model)
        {
            if (id < 1 || model == null)
            {
                return this.BadRequest();
            }

            var user = users.FirstOrDefault(u => u.Id == id);

            user.Name = model.Name;
            user.Email = model.Email;

            return this.Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return this.NotFound();
            }

            this.users.Remove(user);

            return this.NoContent();
        }

        [HttpGet("")]
        public IActionResult Order([FromQuery] string order)
        {
            if (order == "desc")
            {
                return this.Ok(users.OrderByDescending(u => u.Id));
            }
            else
            {
                return this.Ok(users.OrderBy(u => u.Id));
            }
        }
    }
}
