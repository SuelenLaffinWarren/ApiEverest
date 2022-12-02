using AppModels;
using DomainModels.Entities;
using System.Collections.Generic;

namespace AppServices.Services
{
    public interface ICustomerAppService
    {
        void Create(CustomerCreateDto model);
        void Update(CustomerUpdateDto model);
        void Delete(long id);
        IEnumerable<CustomerResult> GetAll();
        CustomerResult GetById(long id);
    }
}
