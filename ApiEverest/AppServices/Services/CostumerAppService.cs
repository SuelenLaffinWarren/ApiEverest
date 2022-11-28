using DomainModels.Entities;

namespace AppServices.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerService;

        public void Create(CustomerEntity customerEntity)
        {
             _customerAppService.Create(customerEntity);
        }

        public void Delete(long id)
        {
           _customerAppService.Delete(id);
        }

        public IEnumerable<CustomerEntity> GetAll()
        {
            return _customerAppService.GetAll();
        }

        public CustomerEntity GetById(long id)
        {
           return _customerAppService.GetById(id);
        }

        public void Update(CustomerEntity customerEntity)
        {
           _customerAppService.Update(customerEntity);
        }
    }
}
