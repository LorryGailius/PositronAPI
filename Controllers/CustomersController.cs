using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.Customer;
using PositronAPI.Services.CustomerService;
using System.ComponentModel.DataAnnotations;

namespace PositronAPI.Controllers
{
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // Customer Endpoints

        /// <summary>
        /// Add a customer
        /// </summary>
        /// <remarks>Creates a customer.</remarks>
        /// <param name="body">Properties for creating a new customer.</param>
        [HttpPost]
        [Route("/customer")]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] CustomerImportDTO body)
        {
            if (IsValidCustomer(body))
            {
                var newCustomer = new Customer { Name = body.Name, Email = body.Email };

                var response = await _customerService.CreateCustomer(newCustomer);

                if (response == null) { return BadRequest(); }
                else { return Created(String.Empty, response); }
            }

            return BadRequest("Given object is not valid");
        }

        /// <summary>
        /// Remove a customer
        /// </summary>
        /// <remarks>Deletes a customer.</remarks>
        /// <param name="customerId">The id of the customer</param>
        [HttpDelete]
        [Route("/customer/{customerId}")]
        public async Task<ActionResult> DeleteCustomer([FromRoute][Required] long customerId)
        {
            var response = await _customerService.DeleteCustomer(customerId);

            if (response == null) { return NotFound(); }
            return NoContent();
        }

        /// <summary>
        /// Edit a customer
        /// </summary>
        /// <remarks>Edits a customer.</remarks>
        /// <param name="body">Properties for creating a new customer.</param>
        /// <param name="customerId">The id of the customer</param>
        [HttpPut]
        [Route("/customer/{customerId}")]
        public async Task<ActionResult> EditCustomer([FromBody][Required] CustomerUpdateDTO body, [FromRoute][Required] long customerId)
        {
            var response = await _customerService.EditCustomer(body, customerId);

            if (response == null) { return NotFound(); }
            return Ok(response);
        }

        /// <summary>
        /// Get a customer
        /// </summary>
        /// <remarks>Gets a customer.</remarks>
        /// <param name="customerId">The id of the customer to get</param>
        [HttpGet]
        [Route("/customer/{customerId}")]
        public async Task<ActionResult<Customer>> GetCustomer([FromRoute][Required] long customerId)
        {
            var response = await _customerService.GetCustomer(customerId);
            if (response == null) { return NotFound(); }
            return Ok(response);
        }

        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <remarks>Get all items.</remarks>
        /// <param name="top">The number of customers to get</param>
        /// <param name="skip">The number of customers to skip over</param>
        [HttpGet]
        [Route("/customer")]
        public async Task<ActionResult<List<Customer>>> GetCustomers([FromQuery] int top, [FromQuery] int skip)
        {
            if (top < 0 || skip < 0) { return BadRequest(); }

            var response = (top > 0 || skip > 0) ? await _customerService.GetCustomers(top, skip) : await _customerService.GetCustomers();

            if (response.Count == 0) { return NoContent(); }

            return Ok(response);
        }
        public bool IsValidCustomer(CustomerImportDTO customer)
        {
            if (customer == null ||
               String.IsNullOrEmpty(customer.Name)) { return false; }

            return true;
        }
    }
}
