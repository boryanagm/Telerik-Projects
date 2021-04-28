using Deliverit.Models.Authentication;
using Deliverit.Services.Contracts;
using Deliverit.Services.Extension_Methods;
using Deliverit.Services.Models;
using DeliverIT.Database;
using DeliverIT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Deliverit.Services
{
    /// <summary>
    /// Class EmployeeService.
    /// Implements the <see cref="Deliverit.Services.Contracts.IEmployeeService" />
    /// Defines all CRUD operations
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly DeliveritDbContext context;

        public EmployeeService(DeliveritDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the employee by email.
        /// </summary>
        /// <param name="employeeEmail">The employee email.</param>
        /// <returns>The employee with the given e-mail.</returns>
        public Employee GetByEmployeeEmail(string employeeEmail)
        {
            return this.context.Employees
                 .FirstOrDefault(e => e.Email == employeeEmail)
                 ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Gets the admin by email.
        /// </summary>
        /// <param name="adminEmail">The admin email.</param>
        /// <returns>The admin with the given e-mail.</returns>
        public Employee GetByAdminEmail(string adminEmail)
        {
            var employeeRole = this.context.Employees
                  .Include(e => e.Roles)
                     .ThenInclude(r => r.Role)
                  .FirstOrDefault(e => e.Email == adminEmail && e.Roles.Any(r => r.Role.Name == "Admin"))
                  ?? throw new ArgumentNullException();

            return employeeRole;
        }

        /// <summary>
        /// Gets the employee by the given identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The employee in a EmployeeDTO format.</returns>
        public EmployeeDTO Get(Guid id)
        {
            var dto = this.context.Employees
              .Select(EmployeeMapper.DTOSelector)
              .FirstOrDefault(e => e.Id == id)
              ?? throw new ArgumentNullException();

            return dto;
        }

        /// <summary>
        /// Gets all Employees.
        /// </summary>
        /// <returns>Returns a collection of all employees.</returns>
        public IEnumerable<EmployeeDTO> GetAll()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();

            foreach (var employee in this.context.Employees
                .Include(e => e.Parcels)
                .Include(e => e.Address)
                  .ThenInclude(a => a.City)
                    .ThenInclude(c => c.Country))
            {
                var dto = EmployeeMapper.DTOSelector.Compile().Invoke(employee);     // Also works EmployeeMapper.DTOSelector.Compile()(employee);
                                                                                     // Compile() is needed because of Expression<Func<>>  
                employees.Add(dto);
                                                                                     // Check with: var dto = employee.ToEmployeeDTO(); - not working
            }

            return employees;
        }

        /// <summary>
        /// Creates an employee.
        /// </summary>
        /// <param name="employee">The employee that is to be created.</param>
        /// <returns>The employee in a EmployeeDTO format.</returns>
        public EmployeeDTO Create(Employee employee)
        {
            this.context.Employees.Add(employee);
            employee.CreatedOn = DateTime.UtcNow;

            var employeeRole = new EmployeeRole()
            {
                Id = Guid.NewGuid(),
                RoleId = Guid.Parse("275a10a1-e965-460e-a965-e1fe2453e916"),
                EmployeeId = employee.Id
            };

            this.context.SaveChanges();

            var dto = this.context.Employees
              .Select(EmployeeMapper.DTOSelector)
              .FirstOrDefault(e => e.Id == employee.Id);

            return dto;
        }

        /// <summary>
        /// Updates the specified employee.
        /// </summary>
        /// <param name="id">The identifier of the employee.</param>
        /// <param name="addressId">The address identifier.</param>
        /// <returns>The updated employee in a EmployeeDTO format.</returns>
        public EmployeeDTO Update(Guid id, Guid addressId)
        {
            var employeeToUpdate = this.context.Employees
               .Include(e => e.Parcels)
               .FirstOrDefault(e => e.Id == id)
               ?? throw new ArgumentNullException();

            employeeToUpdate.ModifiedOn = DateTime.UtcNow;
            employeeToUpdate.AddressId = addressId;
            this.context.SaveChanges();

            employeeToUpdate.Address = this.context.Addresses
               .Include(a => a.City)
                  .ThenInclude(c => c.Country)
               .FirstOrDefault(a => a.Id == addressId);

            var dto = EmployeeMapper.DTOSelector.Compile().Invoke(employeeToUpdate);
            
            return dto;
        }

        /// <summary>
        /// Deletes the specified Employee.
        /// </summary>
        /// <param name="id">The identifier of the employee.</param
        public bool Delete(Guid id)
        {
            var employee = this.context.Employees
                .FirstOrDefault(e => e.Id == id);

            if (employee != null)
            {
                employee.DeletedOn = DateTime.UtcNow;
                employee.IsDeleted = true;
                this.context.SaveChanges();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Restores the specified employee.
        /// </summary>
        /// <param name="id">The identifier of the employee.</param>
        /// <returns>The employee in a EmployeeDTO format.</returns>
        public EmployeeDTO Restore(Guid id) 
        {
            var employeeToRestore = this.context.Employees
                .IgnoreQueryFilters()
                .FirstOrDefault(e => e.Id == id); 

            employeeToRestore.IsDeleted = false;
            this.context.SaveChanges();

            var dto = this.context.Employees
              .Select(EmployeeMapper.DTOSelector)
              .FirstOrDefault(c => c.Id == employeeToRestore.Id)
              ?? throw new ArgumentNullException();

            return dto;
        }
    }
}
