
using Beers.Services.Contracts;
using Beers.Services.Models;
using Beers.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Beers.Web.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BeersController : ControllerBase
	{
		private readonly IBeerService beerService;
        private readonly IAuthHelper authHelper;

        public BeersController(IBeerService beerService, IAuthHelper authHelper)
		{
			this.beerService = beerService;
            this.authHelper = authHelper;
        }

		// GET api/beers/:id
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			BeerDTO beer = this.beerService.Get(id);

			return Ok(beer);
		}

		// GET api/beers/
		[HttpGet("")]
		public IActionResult GetAll()
		{
			var beers = this.beerService.GetAll();
			return Ok(beers);
		}

		[HttpPut("{id}")]
		public IActionResult Put([FromHeader] string authorization, int id, string name)
		{
            try
            {
				this.authHelper.TryGetUser(authorization);
				var beerToUpdate = this.beerService.Update(id, name);
				return Ok(beerToUpdate);
            }
            catch (Exception e)
            {
				return BadRequest(e.Message);
            }
		}

		// GET api/beers/delete/:id
		[HttpGet("delete/{id}")]
		public IActionResult Delete(int id)
		{
			this.beerService.Delete(id);
			return NoContent();
		}
	}
}
