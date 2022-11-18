using ApiEverest.Entities;
using CustomerApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CostumerController(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _customerService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var response = _customerService.GetById(id);
                return Ok(response);
            }
            catch (ArgumentNullException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return NotFound(message);
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody]CustomerEntity customerModel)
        {
            try
            {
                var response = _customerService.Create(customerModel);
                return Ok(response);

            }
            catch(ArgumentNullException exception) 
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
                
        }

        [HttpPut("{id}")]
        public IActionResult Update(CustomerEntity customerModel)
        {
            try
            {
                var result = _customerService.Update(customerModel);
                if (!result)
                    return BadRequest("O usuário já existe");
                
                return Ok(result);
            

            }
            catch(ArgumentNullException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return NotFound(message);
            }
           
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            try
            {
                var response = _customerService.Delete(id);
                return Ok(response);

            }
            catch (ArgumentNullException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return NotFound(message);
            }

        }

    }
}
