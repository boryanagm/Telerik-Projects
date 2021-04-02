using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreOverview.Controllers
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
