using CustomerApi.Models.Entities;
using CustomerApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<CustomerEntity> GetAll()
        {
            var response = _customerService.GetAll();
            return response;
        }


        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var response = _customerService.GetById(id);

            return response != null
                ? Ok(response)
                : NotFound($"Customer não encontrado para o Id: {id}");
        }

        [HttpPost]

        public ActionResult Create([FromBody]CustomerEntity customerModel)
        {
            var response = _customerService.Create(customerModel);
            return response
                ? Created("Dados inseridos com sucesso", customerModel.Id)
                : BadRequest("Erro ao salvar customer");
        }

        [HttpPut("{id}")]
        public IActionResult Update(CustomerEntity customerModel)
        {
            var result = _customerService.Update(customerModel);
           
            if (result)
            {
                return Ok();
            }
            else if (!result)
            {
                return BadRequest("O usuário já existe");
            }

            return NotFound($"Sem customer para Id = {customerModel.Id}");

        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            
            var response = _customerService.Delete(id);

           
            return response
                ? Ok()
                : NotFound($"Customer não encontrado para Id: {id}");
   
        }

    }
}
