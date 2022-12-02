using AppModels;
using System.Collections.Generic;

namespace AppServices.Services
{
    public interface ICustomerAppService
    {
        void Create(CustomerCreateDto customerCreateDto);
        void Update(CustomerUpdateDto customerUpdateDto);
        void Delete(long id);
        IEnumerable<CustomerResult> GetAll();
        CustomerResult GetById(long id);
    }
}
