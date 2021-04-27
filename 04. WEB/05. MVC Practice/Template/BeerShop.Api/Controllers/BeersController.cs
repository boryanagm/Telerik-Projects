using BeerShop.Data.Models;
using BeerShop.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Testing.Web.Controllers
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
            var beers = this.beerService.GetAll();

            return this.Ok(beers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var beer = this.beerService.Get(id);
            return this.Ok(beer);
        }

        [HttpPost("")]
        public IActionResult Post([FromBody] Beer model)
        {
            try
            {
                var beer = this.beerService.Create(model);
                return this.Created("post", beer);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, string name)
        {
            try
            {
                var updatedBeer = this.beerService.Update(id, name);
                return this.Ok(updatedBeer);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromHeader] string authorization, int id)
        {
            try
            {
                this.beerService.Delete(id);
                return this.NoContent();
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}
