#nullable enable
using System;
using ExampleTest_Tutorial_13.Models;
using ExampleTest_Tutorial_13.Models.Requests;
using ExampleTest_Tutorial_13.Services;
using ExampleTest_Tutorial_13.Util;
using Microsoft.AspNetCore.Mvc;

namespace ExampleTest_Tutorial_13.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersDbService _dbService;

        public OrdersController(IOrdersDbService service)
        {
            _dbService = service;
        }

        public IActionResult GetOrders(string? customerSurname)
        {
            AllOrdersResponse response = new AllOrdersResponse();
            if (string.IsNullOrEmpty(customerSurname))
            {
                response.Response = _dbService.GetAllCustomersOrders();
                return Ok(response);
            }


            var customer = _dbService.GetCustomerBySurname(customerSurname);
            if (customer == null)
            {
                return NotFound("Customer with surname " + customerSurname + " doesnt exist");
            }

            response.Response = _dbService.GetCustomerOrders(customer.IdCustomer);
            return Ok(response);
        }
    }
}