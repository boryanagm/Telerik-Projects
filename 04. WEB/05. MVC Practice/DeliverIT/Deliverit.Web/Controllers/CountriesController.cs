using Deliverit.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Deliverit.Web.Controllers
{
    namespace Deliverit.Web.Controllers
    {
        /// <summary>
        /// Class CountriesController.
        /// Handles all contry services
        /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
        /// </summary>
        [Route("api/[controller]")]
        [ApiController]
        public class CountriesController : ControllerBase
        {
            private readonly ICountryService countryService;

            public CountriesController(ICountryService countryService)
            {
                this.countryService = countryService;
            }

            /// <summary>
            /// Shows country by ID.
            /// </summary>
            /// <param name="id">The identifier.</param>
            [HttpGet("{id}")]
            public IActionResult Get(Guid id)
            {
                try
                {
                    return this.Ok(this.countryService.Get(id));
                }

                catch (Exception)
                {
                    return this.NotFound();
                }
            }

            /// <summary>
            /// Shows all countries.
            /// </summary>
            [HttpGet("")]
            public IActionResult GetAll()
            {
                return this.Ok(this.countryService.GetAll());
            }
        }
    }
}
