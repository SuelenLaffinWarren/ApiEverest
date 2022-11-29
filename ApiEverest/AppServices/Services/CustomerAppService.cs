using DomainModels.Entities;
using DomainServices.Services;
using System.Collections.Generic;

namespace AppServices.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerService;

        public CustomerAppService(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new System.ArgumentNullException(nameof(customerService));
        }

        public void Create(CustomerEntity customerEntity)
        {
            _customerService.Create(customerEntity);
        }

        public void Delete(long id)
        {
            _customerService.Delete(id);
        }

        public IEnumerable<CustomerEntity> GetAll()
        {
            return _customerService.GetAll();
        }

        public CustomerEntity GetById(long id)
        {
           return _customerService.GetById(id);
        }

        public void Update(CustomerEntity customerEntity)
        {
            _customerService.Update(customerEntity);
        }
    }
}
