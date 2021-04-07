using LayeredArchitecture.Data.Models;
using LayeredArchitecture.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LayeredArchitecture.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return this.Ok(this.userService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = this.userService.Get(id);

                return this.Ok(user);
            }
            catch (ArgumentNullException)
            {
                return this.NotFound();
            }
        }

        [HttpPost("")]
        public IActionResult Post([FromBody] User model)
        {
            var user = this.userService.Create(model);

            return this.Created("post", model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User model)
        {
            try
            {
                var user = this.userService.Update(id, model);
                return this.Ok(model);
            }
            catch (ArgumentNullException)
            {
                return this.Conflict();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = this.userService.Delete(id);

            if (success)
            {
                return this.NoContent();
            }

            return this.NotFound();
        }
    }
}
