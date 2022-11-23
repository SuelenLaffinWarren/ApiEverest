using ApiEverest.Entities;
using System.Collections.Generic;

namespace CustomerApi.Services
{
    public interface ICustomerService 
    {
        void Create(CustomerEntity model);
        void Update(CustomerEntity model);
        void Delete(long id);
        IEnumerable<CustomerEntity> GetAll();
        CustomerEntity? GetById(long id);
    }
}
