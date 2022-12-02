using AppModels;
using AppServices.Services;
using AutoMapper;
using DomainModels.Entities;
using DomainServices.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ApiEverest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly ICustomerAppService _customerService;
        public CostumerController(ICustomerAppService customerService)
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
        public IActionResult Create([FromBody] CustomerCreateDto customerEntity)
        {
            try
            {
                _customerService.Create(customerEntity);
                return Created("Id:", customerEntity.Id);
            }
            catch (ArgumentException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(CustomerUpdateDto customerEntity)
        {
            try
            {
                _customerService.Update(customerEntity);
                return Ok();
            }
            catch (ArgumentNullException exception)
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
