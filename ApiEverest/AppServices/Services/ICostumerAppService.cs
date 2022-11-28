using DomainModels.Entities;
using System.Collections.Generic;

namespace AppServices.Services
{
    public interface ICustomerAppService
    {
        void Create(CustomerEntity model);
        void Update(CustomerEntity model);
        void Delete(long id);
        IEnumerable<CustomerEntity> GetAll();
        CustomerEntity GetById(long id);
    }
}
