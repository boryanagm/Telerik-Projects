using Deliverit.Services.Contracts;
using Deliverit.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Deliverit.Web.Controllers
{
    /// <summary>
    /// Class CitiesController.
    /// Handles all city services
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService cityService;
        private readonly IAuthEmployeeHelper autHelper;

        public CitiesController(ICityService cityService, IAuthEmployeeHelper autHelper)
        {
            this.cityService = cityService;
            this.autHelper = autHelper;
        }

        /// <summary>
        /// Shows city by ID.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return this.Ok(this.cityService.Get(id));
            }
            catch(Exception)
            {
                return this.NotFound();
            }
        }

        /// <summary>
        /// Shows all cities.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet("")]
        public IActionResult GetAll()
        {
            return this.Ok(this.cityService.GetAll());
        }
    }
}
