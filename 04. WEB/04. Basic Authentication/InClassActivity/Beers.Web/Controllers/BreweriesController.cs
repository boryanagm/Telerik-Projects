
using Beers.Services.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace Beers.Web.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BreweriesController : ControllerBase
	{
		private readonly IBreweryService breweryService;

		public BreweriesController(IBreweryService beerService)
		{
			this.breweryService = beerService;
		}

		// GET api/beers/
		[HttpGet("")]
		public IActionResult GetAll()
		{
			var breweries = this.breweryService.GetAll();
			return Ok(breweries);
		}

		// GET api/breweries/delete/:id
		[HttpGet("delete/{id}")]
		public IActionResult Delete(int id)
		{
			this.breweryService.Delete(id);

			return NoContent();
		}
	}
}
