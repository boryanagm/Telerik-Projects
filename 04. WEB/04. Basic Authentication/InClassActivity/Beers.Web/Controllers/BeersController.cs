
using Beers.Services.Contracts;
using Beers.Services.Models;

using Microsoft.AspNetCore.Mvc;

namespace Beers.Web.Controllers
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

		// GET api/beers/delete/:id
		[HttpGet("delete/{id}")]
		public IActionResult Delete(int id)
		{
			this.beerService.Delete(id);
			return NoContent();
		}
	}
}
