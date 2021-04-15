
using Beers.Services.Contracts;
using Beers.Services.Models;

using Microsoft.AspNetCore.Mvc;

namespace Beers.Web.Controllers
{
	[ApiController]
	[Route("api/users")]
	public class UserController : ControllerBase
	{
		private readonly IUserService userService;

		public UserController(IUserService userService)
		{
			this.userService = userService;
		}

		// GET api/users/search?name=&country=
		[HttpGet("search")]
		public IActionResult Get([FromQuery] string name, string country)
		{
			UserDTO dto = this.userService.Get(name);

			return Ok(dto);
		}
	}
}
