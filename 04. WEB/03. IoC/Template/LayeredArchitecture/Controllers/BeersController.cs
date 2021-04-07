using LayeredArchitecture.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using LayeredArchitecture.Data.Models;

namespace LayeredArchitecture.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeersController : ControllerBase
    {
        private readonly IBeerService beerService;

        public BeersController(IBeerService beerService)
        {
            this.beerService = beerService;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return this.Ok(this.beerService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var beer = this.beerService.Get(id);

                return this.Ok(beer);
            }
            catch (ArgumentNullException)
            {
                return this.NotFound();
            }
        }

        [HttpPost("")]
        public IActionResult Post([FromBody] Beer model)
        {
            var beer = this.beerService.Create(model);

            return this.Created("post", model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Beer model)
        {
            try
            {
                var beer = this.beerService.Update(id, model);

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
            var success = this.beerService.Delete(id);

            if (success)
            {
                return this.NoContent();
            }

            return this.NotFound();
        }
    }
}
