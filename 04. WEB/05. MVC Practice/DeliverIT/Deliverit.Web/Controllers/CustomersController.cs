using Deliverit.Services;
using Deliverit.Services.Contracts;
using Deliverit.Web.Helpers;
using DeliverIT.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Deliverit.Web.Controllers
{
    /// <summary>
    /// Class CustomersController.
    /// Handles all customer services.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IAuthEmployeeHelper authEmployeeHelper;
        private readonly IAuthCustomerHelper authCustomerHelper;

        public CustomersController(ICustomerService customerService, IAuthEmployeeHelper authEmployeeHelper, IAuthCustomerHelper authCustomerHelper)
        {
            this.customerService = customerService;
            this.authEmployeeHelper = authEmployeeHelper;
            this.authCustomerHelper = authCustomerHelper;
        }

        /// <summary>
        /// Gets a customer by email.
        /// </summary>
        /// <param name="authorizationEmail">The authorization email.</param>
        /// <param name="id">The identifier of the customer.</param>
        [HttpGet("{id}")]
        public IActionResult Get([FromHeader] string authorizationEmail, Guid id)
        {
            try
            {
                var customer = this.authCustomerHelper.TryGetCustomer(authorizationEmail);

                if (customer.Id != id)
                {
                    return this.Forbid();
                }

                return this.Ok(this.customerService.Get(id));
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
        /// Gets all customers.
        /// </summary>
        /// <param name="authorizationEmail">The authorization email.</param>
        [HttpGet("")]
        public IActionResult GetAll([FromHeader] string authorizationEmail)
        {
            try
            {
                var employee = this.authEmployeeHelper.TryGetEmployee(authorizationEmail);
                return this.Ok(this.customerService.GetAll());
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
        /// Gets the count of all customers.
        /// </summary>
        [HttpGet("/count")]
        public IActionResult GetCount()
        {
            return this.Ok(this.customerService.GetCount());
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="customer">The customer that is to be created.</param>
        [HttpPost("")]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            try
            {
                var newCustomer = this.customerService.Create(customer);

                return this.Created("post", newCustomer);
            }
            catch (Exception)
            { 
                return this.BadRequest(); 
            }
        }

        /// <summary>
        /// Updates a customer's information.
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
                var customerToUpdate = this.customerService.Update(id, addressId);
                return this.Ok(customerToUpdate);
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
        /// Deletes a customer.
        /// </summary>
        /// <param name="authorizationEmail">The authorization email.</param>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromHeader] string authorizationEmail, Guid id)     // TODO: The customer should also be able to delete his/her profile
        {
            try
            {
                var employee = this.authEmployeeHelper.TryGetEmployee(authorizationEmail);
                var success = this.customerService.Delete(id);

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
        /// Gets all incoming parcels of a customer by his ID.
        /// </summary>
        /// <param name="authorizationEmail">The authorization email.</param>
        /// <param name="id">The identifier.</param>
        [HttpGet("{id}/incoming")]
        public IActionResult GetIncomingParcels([FromHeader] string authorizationEmail, Guid id)
        {
            try
            {
                var customer = this.authCustomerHelper.TryGetCustomer(authorizationEmail);

                if (customer.Id != id)
                {
                    return this.Forbid();
                }

                return this.Ok(this.customerService.GetIncomingParcels(id));
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
        /// Gets all past parcels of a customer by his ID.
        /// </summary>
        /// <param name="authorizationEmail">The authorization email.</param>
        /// <param name="id">The identifier.</param>
        [HttpGet("{id}/past")]
        public IActionResult GetPastParcels([FromHeader] string authorizationEmail, Guid id)
        {
            try
            {
                var customer = this.authCustomerHelper.TryGetCustomer(authorizationEmail);

                if (customer.Id != id)
                {
                    return this.Forbid();
                }

                return this.Ok(this.customerService.GetPastParcels(id));
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
        /// Gets customers by a key word.
        /// </summary>
        /// <param name="authorizationEmail">The authorization email.</param>
        /// <param name="key">The key.</param>
        [HttpGet("{key}/all")]
        public IActionResult GetByKeyWord([FromHeader] string authorizationEmail, string key)
        {
            try
            {
                var employee = this.authEmployeeHelper.TryGetEmployee(authorizationEmail);
                return this.Ok(this.customerService.GetByKeyWord(key));
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
        /// Gets customers by multiple criteria.
        /// </summary>
        /// <param name="authorizationEmail">The authorization email.</param>
        /// <param name="customerFilter">The customer filter.</param>
        [HttpGet("/multiple")]
        public IActionResult GetByMultipleCriteria([FromHeader] string authorizationEmail, [FromQuery] CustomerFilter customerFilter)
        {
            try
            {
                var employee = this.authEmployeeHelper.TryGetEmployee(authorizationEmail);
                return this.Ok(this.customerService.GetByMultipleCriteria(customerFilter));
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