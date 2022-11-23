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
        public IActionResult Create([FromBody]CustomerEntity customerEntity)
        {
            try
            {
                _customerService.Create(customerEntity);
                return Created("Id:", customerEntity.Id);

            }
            catch(ArgumentException exception) 
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(CustomerEntity customerEntity)
        {
            try
            {
                _customerService.Update(customerEntity);
                    return Ok();
            
            }
            catch(ArgumentNullException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return NotFound(message);
            }
            catch (ArgumentException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _customerService.Delete(id);
                return NoContent();

            }
            catch (ArgumentNullException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return NotFound(message);
            }
        }
    }
}
