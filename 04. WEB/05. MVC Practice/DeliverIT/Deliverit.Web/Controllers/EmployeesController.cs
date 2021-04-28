using Deliverit.Services.Contracts;
using Deliverit.Web.Helpers;
using DeliverIT.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Deliverit.Web.Controllers
{
    /// <summary>
    /// Class EmployeesController.
    /// Handles all Employee services.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly IAuthEmployeeHelper authEmployeeHelper;

        public EmployeesController(IEmployeeService employeeService, IAuthEmployeeHelper authEmployeeHelper)
        {
            this.employeeService = employeeService;
            this.authEmployeeHelper = authEmployeeHelper;
        }

        /// <summary>
        /// Gets an employee by his ID.
        /// </summary>
        /// <param name="authorizationEmail">The authorization email.</param>
        /// <param name="id">The identifier.</param>
        [HttpGet("{id}")]
        public IActionResult Get([FromHeader] string authorizationEmail, Guid id)
        {
            try
            {
                var admin = this.authEmployeeHelper.TryGetAdmin(authorizationEmail);
                return this.Ok(this.employeeService.Get(id));
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
        /// Gets all employees.
        /// </summary>
        /// <param name="authorizationEmail">The authorization email.</param>
        [HttpGet("")]
        public IActionResult GetAll([FromHeader] string authorizationEmail)
        {
            try
            {
                var admin = this.authEmployeeHelper.TryGetAdmin(authorizationEmail);
                return this.Ok(this.employeeService.GetAll());
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
        /// Creates an employee.
        /// </summary>
        /// <param name="authorizationEmail">The authorization email.</param>
        /// <param name="employee">The employee that is to be created.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost("")]
        public IActionResult Post([FromHeader] string authorizationEmail, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            try
            {
                var admin = this.authEmployeeHelper.TryGetAdmin(authorizationEmail);
                var employeeToUpdate = this.employeeService.Create(employee);
                return this.Created("post", employeeToUpdate);
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
        /// Updates an employee.
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
                var admin = this.authEmployeeHelper.TryGetAdmin(authorizationEmail);
                var employeeToUpdate = this.employeeService.Update(id, addressId);
                return this.Ok(employeeToUpdate);
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
        /// Deletes an employee by Id.
        /// </summary>
        /// <param name="authorizationEmail">The authorization email.</param>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromHeader] string authorizationEmail, Guid id)
        {
            try
            {
                var admin = this.authEmployeeHelper.TryGetAdmin(authorizationEmail);
                var success = this.employeeService.Delete(id);

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

        /// <summary>
        /// Restores the specified employee by Id.
        /// </summary>
        /// <param name="authorizationEmail">The authorization email.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost("{id}/restore")] 
        public IActionResult Restore([FromHeader] string authorizationEmail, Guid id)
        {
            try
            {
                var admin = this.authEmployeeHelper.TryGetAdmin(authorizationEmail);
                var employeeToRestore = this.employeeService.Restore(id);
                return this.Created("post", employeeToRestore);
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
