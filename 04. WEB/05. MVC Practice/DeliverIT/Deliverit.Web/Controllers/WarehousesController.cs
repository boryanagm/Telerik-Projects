using Deliverit.Services.Contracts;
using Deliverit.Web.Helpers;
using DeliverIT.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Deliverit.Web.Controllers
{
    /// <summary>
    /// Class WarehousesController.
    /// Handles all warehouse services.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseService warehouseService;
        private readonly IAuthEmployeeHelper authEmployeeHelper;

        public WarehousesController(IWarehouseService warehouseService, IAuthEmployeeHelper authEmployeeHelper)
        {
            this.warehouseService = warehouseService;
            this.authEmployeeHelper = authEmployeeHelper;
        }

        /// <summary>
        /// Gets the a warehouse by Id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id) // public part
        {
            try
            {
                return this.Ok(this.warehouseService.Get(id));
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }

        /// <summary>
        /// Gets all warehouses.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet("")]
        public IActionResult GetAll()
        {
            return this.Ok(this.warehouseService.GetAll());
        }

        /// <summary>
        /// Creates a warehouse.
        /// </summary>
        /// <param name="authorizationEmail">The authorization email.</param>
        /// <param name="warehouse">The warehouse.</param>
        [HttpPost("")]
        public IActionResult Post([FromHeader] string authorizationEmail, [FromBody] Warehouse warehouse)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            try
            {
                var employee = this.authEmployeeHelper.TryGetEmployee(authorizationEmail);
                var warehouseToUpdate = this.warehouseService.Create(warehouse);

                return this.Created("post", warehouseToUpdate);
            }
            catch (UnauthorizedAccessException)
            {
                return this.Forbid();
            }
            catch(Exception)
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Updates a warehouse.
        /// </summary>
        /// <param name="authorizationEmail">The authorization email.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="addressId">The address identifier.</param>
        [HttpPut("{id}")]
        public IActionResult Put([FromHeader] string authorizationEmail, Guid id, Guid addressId)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            try
            {
                var employee = this.authEmployeeHelper.TryGetEmployee(authorizationEmail);
                var warehouseToUpdate = this.warehouseService.Update(id, addressId);

                return this.Ok(warehouseToUpdate);
            }
            catch (UnauthorizedAccessException)
            {
                return this.Forbid();
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Deletes a warehouse.
        /// </summary>
        /// <param name="authorizationEmail">The authorization email.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete("{id}")] // admin only
        public IActionResult Delete([FromHeader] string authorizationEmail, Guid id)
        {
            try
            {
                var admin = this.authEmployeeHelper.TryGetAdmin(authorizationEmail);
                var success = this.warehouseService.Delete(id);

                if (success)
                {
                    return this.NoContent();
                }
                else
                {
                    return this.NotFound();
                }
            }
            catch (UnauthorizedAccessException)
            {
                return this.Forbid();
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
    }
}
