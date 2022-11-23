using DomainModels.Entities;

namespace DomainServices.Services
{
    public interface ICustomerService
    {
        void Create(CustomerEntity model);
        void Update(CustomerEntity model);
        void Delete(long id);
        IEnumerable<CustomerEntity> GetAll();
        CustomerEntity GetById(long id);
    }
}
