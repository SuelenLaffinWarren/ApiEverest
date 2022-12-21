using AppModels;
using System.Collections.Generic;

namespace AppServices.Services
{
    public interface ICustomerAppService
    {
        long Create(CustomerCreateDto customerCreateDto);
        void Update(CustomerUpdateDto customerUpdateDto, long id);
        void Delete(long id);
        IEnumerable<CustomerResultDto> GetAll();
        CustomerResultDto GetById(long id);
    }
}