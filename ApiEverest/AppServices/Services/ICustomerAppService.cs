using AppModels;
using System.Collections.Generic;

namespace AppServices.Services
{
    public interface ICustomerAppService
    {
        void Create(CustomerCreateDto customerCreateDto);
        void Update(CustomerUpdateDto customerUpdateDto);
        void Delete(long id);
        IEnumerable<CustomerResultDto> GetAll();
        CustomerResultDto GetById(long id);
    }
}
