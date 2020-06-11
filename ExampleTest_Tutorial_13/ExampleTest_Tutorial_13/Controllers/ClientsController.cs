using System;
using ExampleTest_Tutorial_13.Models.Requests;
using ExampleTest_Tutorial_13.Services;
using ExampleTest_Tutorial_13.Util;
using Microsoft.AspNetCore.Mvc;

namespace ExampleTest_Tutorial_13.Controllers
{

    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IOrdersDbService _dbService;

        public ClientsController(IOrdersDbService service)
        {
            _dbService = service;
        }

        [HttpPost("{idCustomer}/orders")]
        public IActionResult AddNewOrder(NewOrderRequest newOrderRequest, string idCustomer)
        {
            var errorList = ValidationHelper.ValidateNewOrderRequest(newOrderRequest);
            if (errorList.Count > 0)
            {
                return BadRequest(errorList);
            }
            
            try
            {
                var response = _dbService.AddNewOrder(newOrderRequest, idCustomer);
                return StatusCode(201,response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}