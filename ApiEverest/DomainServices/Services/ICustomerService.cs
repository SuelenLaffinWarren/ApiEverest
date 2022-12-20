using DomainModels.Entities;
using System.Collections.Generic;

namespace DomainServices.Services
{
    public interface ICustomerService
    {
        long Create(CustomerEntity model);
        void Update(CustomerEntity model);
        void Delete(long id);
        IEnumerable<CustomerEntity> GetAll();
        CustomerEntity GetById(long id);
    }
}
