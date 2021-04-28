using Deliverit.Services.Contracts;
using Deliverit.Services.Models;
using Deliverit.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Deliverit.Web.Controllers
{
    /// <summary>
    /// Class ParcelController.
    /// Handles all parcel services.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelController : Controller
    {
        private readonly IParcelService parcelService;
        private readonly IAuthEmployeeHelper authEmployeeHelper;
        private readonly IAuthCustomerHelper authCustomerHelper;
        public ParcelController(IParcelService parcelService, IAuthEmployeeHelper authEmployeeHelper, IAuthCustomerHelper authCustomerHelper)
        {
            this.parcelService = parcelService;
            this.authEmployeeHelper = authEmployeeHelper;
            this.authCustomerHelper = authCustomerHelper;
        }

        /// <summary>
        /// Gets a parcel by ID.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="authorizationEmail">The authorization email.</param>
        [HttpGet("{id}")]
        public IActionResult Get([FromHeader] string authorizationEmail, Guid id)
        {
            try
            {
                var employee = this.authEmployeeHelper.TryGetEmployee(authorizationEmail);
                return this.Ok(this.parcelService.Get(id));
            }
            catch (UnauthorizedAccessException)
            {
                return this.Forbid();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Gets all Parcels.
        /// </summary>
        [HttpGet("")]
        public IActionResult GetAll()
        {
            return this.Ok(this.parcelService.GetAll());
        }

        /// <summary>
        /// Creates a parcel.
        /// </summary>
        /// <param name="authorizationEmail">The authorization email.</param>
        /// <param name="parcel">The parcel.</param>
        [HttpPost("")]
        public IActionResult Post([FromHeader] string authorizationEmail, [FromQuery] CreateParcelDTO parcel)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            try
            {
                var employee = this.authEmployeeHelper.TryGetEmployee(authorizationEmail);
                var parcelToCreate = this.parcelService.Create(parcel);
                return this.Created("post", parcelToCreate);
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
        /// Updates a parcel by Id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="parcel">The parcel.</param>
        /// <param name="authorizationEmail">The authorization email.</param>
        [HttpPut("{id}")]
        public IActionResult Put([FromHeader] string authorizationEmail, Guid id, [FromQuery] UpdateParcelDTO parcel)
        {          
            try
            {
                var employee = this.authEmployeeHelper.TryGetEmployee(authorizationEmail);
                var parcelToUpdate = this.parcelService.Update(id, parcel);

                return this.Ok(parcelToUpdate);
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
        /// Deletes a parcel by Id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="authorizationEmail">The authorization email.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromHeader] string authorizationEmail, Guid id)
        {
            try
            {
                var employee = this.authEmployeeHelper.TryGetEmployee(authorizationEmail);
                var success = this.parcelService.Delete(id);

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
        /// Filters parcels by e-mail.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="authorizationEmail">The authorization email.</param>
        [HttpGet("filter/email/{email}")]
        public IActionResult SearchByEmail([FromHeader] string authorizationEmail, string email)
        {
            try
            {
                var employee = this.authEmployeeHelper.TryGetEmployee(authorizationEmail);
                return this.Ok(this.parcelService.SearchByEmail(email));
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
        /// Filters parcels by customer's first and last names.
        /// </summary>
        /// <param name="firstname">The firstname.</param>
        /// <param name="lastname">The lastname.</param>
        /// <param name="authorizationEmail">The authorization email.</param>
        [HttpGet("filter/name/")]
        public IActionResult SearchByName([FromHeader] string authorizationEmail, [FromQuery] string firstname, [FromQuery] string lastname)
        {
            try
            {
                var employee = this.authEmployeeHelper.TryGetEmployee(authorizationEmail);
                return this.Ok(this.parcelService.SearchByName(firstname, lastname));
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
        /// Filters all of a customer's incoming parcels by his ID.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        /// <param name="authorizationEmail">The authorization email.</param>
        [HttpGet("filter/incoming/{Id}")]
        public IActionResult SearchByIncomingShippment([FromHeader] string authorizationEmail, Guid Id)
        {
            try
            {
                try
                {
                    var employee = this.authEmployeeHelper.TryGetEmployee(authorizationEmail);
                    return this.Ok(this.parcelService.FindIncomingParcels(Id));
                }
                catch (Exception)
                {
                    var customer = this.authCustomerHelper.TryGetCustomer(authorizationEmail);
                    if (customer.Id == Id)
                        return this.Ok(this.parcelService.FindIncomingParcels(Id));
                    else
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
        /// Filters by warehouse Id.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        /// <param name="authorizationEmail">The authorization email.</param>
        [HttpGet("filter/warehouse/{Id}")]
        public IActionResult GetByWarehouse([FromHeader] string authorizationEmail, Guid Id)
        {
            try
            {
                var employee = this.authEmployeeHelper.TryGetEmployee(authorizationEmail);
                return this.Ok(this.parcelService.GetByWarehouse(Id));
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
        /// Filters parcels by customer Id.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        /// <param name="authorizationEmail">The authorization email.</param>
        [HttpGet("filter/customer/{Id}")]
        public IActionResult GetByCustomer([FromHeader] string authorizationEmail, Guid Id)
        {
            try
            {
                try
                {
                    var employee = this.authEmployeeHelper.TryGetEmployee(authorizationEmail);
                    return this.Ok(this.parcelService.GetByCustomer(Id));
                }
                catch (Exception)
                {
                    var customer = this.authCustomerHelper.TryGetCustomer(authorizationEmail);
                    if (customer.Id == Id)
                        return this.Ok(this.parcelService.GetByCustomer(Id));
                    else
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
        /// Filters parcels by weight.
        /// </summary>
        /// <param name="weight">The weight.</param>
        /// <param name="authorizationEmail">The authorization email.</param>
        [HttpGet("filter/weight/{weight}")]
        public IActionResult GetByWeight([FromHeader] string authorizationEmail, int weight)
        {
            try
            {
                var employee = this.authEmployeeHelper.TryGetEmployee(authorizationEmail);
                return this.Ok(this.parcelService.GetByWeight(weight));
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
        /// Filters parcels by category.
        /// </summary>
        /// <param name="category">The category.</param>   
        /// <param name="authorizationEmail">The authorization email.</param>
        [HttpGet("filter/category/{category}")]
        public IActionResult GetByCategory([FromHeader] string authorizationEmail, string category)
        {
            try
            {
                var employee = this.authEmployeeHelper.TryGetEmployee(authorizationEmail);
                return this.Ok(this.parcelService.GetByCategory(category));
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
        /// Filters parcels by category and Id.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="Id"></param>   
        /// <param name="authorizationEmail">The authorization email.</param>
        [HttpGet("filter/multiplecriteria")]
        public IActionResult GetByMultipleCriteria([FromHeader] string authorizationEmail, [FromQuery] string category, [FromQuery] Guid Id)
        {
            try
            {
                var employee = this.authEmployeeHelper.TryGetEmployee(authorizationEmail);
                return this.Ok(this.parcelService.GetByMultipleCriteria(category, Id));
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
        /// Sorts by weight or arrival date.
        /// </summary>        
        /// <param name="criteria">The criteria.</param> 
        /// <param name="authorizationEmail">The authorization email.</param>
        [HttpGet("filter/weightordate/{criteria}")]
        public IActionResult SortByWeightOrDate([FromHeader] string authorizationEmail, string criteria)
        {
            try
            {
                var employee = this.authEmployeeHelper.TryGetEmployee(authorizationEmail);
                return this.Ok(this.parcelService.SortByWeightOrArrivalDate(criteria));
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
