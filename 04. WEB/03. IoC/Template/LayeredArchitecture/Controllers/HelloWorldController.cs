using Microsoft.AspNetCore.Mvc;

namespace LayeredArchitecture.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        public string SayHello()
        {
            return "Hello, World!";
        }
    }
}
