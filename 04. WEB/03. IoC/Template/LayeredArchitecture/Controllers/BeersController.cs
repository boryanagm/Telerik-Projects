using LayeredArchitecture.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LayeredArchitecture.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeersController : ControllerBase
    {
        private readonly List<Beer> beers = new List<Beer>
        {
            new Beer
            {
                Id = 1,
                Name = "Glarus English Ale",
                Abv = 4.6
            },
            new Beer
            {
                Id = 2,
                Name = "Rhombus Porter",
                Abv = 5.0
            },
        };

        [HttpGet("")]
        public IActionResult Get()
        {
            return this.Ok(this.beers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var beer = this.beers.FirstOrDefault(beer => beer.Id == id);

            if (beer == null)
            {
                return this.NotFound();
            }

            return this.Ok(beer);
        }

        [HttpPost("")]
        public IActionResult Post([FromBody] Beer model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            //Does NOT work => controllers are resolved on each request - demo purposes
            this.beers.Add(model);

            return this.Created("post", model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Beer model)
        {
            if (id < 1 || model == null)
            {
                return this.BadRequest();
            }

            var beer = this.beers.FirstOrDefault(beer => beer.Id == id);

            //Does NOT work => controllers are resolved on each request - demo purposes
            beer.Name = model.Name;
            beer.Abv = model.Abv;

            return this.Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var beer = this.beers.FirstOrDefault(beer => beer.Id == id);

            if (beer == null)
            {
                return this.NotFound();
            }

            //Does NOT work => controllers are resolved on each request - demo purposes
            this.beers.Remove(beer);

            return this.NoContent();
        }
    }
}
