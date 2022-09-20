using InterSport.Domain.Entities;
using InterSport.Domain.Interfaces.Services;
using System;
using System.Web.Http;

namespace InterSport.API.Controllers
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService _customerService)
        {
            customerService = _customerService;
        }

        [HttpGet]
        [Route("GetListCustomers")]
        public IHttpActionResult GetListCustomers()
        {
            try
            {
               var listCustomer = customerService.GetListCustomers();
                if (listCustomer != null) return Ok(listCustomer);
                return Ok("There ir not products");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        public IHttpActionResult DeleteCustomer(int customerId)
        {
            try
            {
                var response = customerService.DeleteCustomerById(customerId);
                if (response) return Ok(response);
                return Ok("Not Deleted");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetCustomerById")]
        public IHttpActionResult GetCustomerById(int customerId)
        {
            try
            {
                var response = customerService.GetCustomerById(customerId);
                if (response != null) return Ok(response);
                return Ok("Not found");

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("UpdateCustomer")]
        public IHttpActionResult UpdateCustomer(Customer customer)
        {
            try
            {
                var response = customerService.UpdateCustomer(customer);
                if (response) return Ok(response);
                return Ok("Error");

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}